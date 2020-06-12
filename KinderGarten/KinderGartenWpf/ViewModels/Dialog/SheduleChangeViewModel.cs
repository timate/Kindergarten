using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Dialog
{
    public class SheduleChangeViewModel : DialogViewModel
    {
        #region Свойства
        public Visibility AddVisibility { get; set; }
        public Visibility ChangeVisibility { get; set; }
        public Visibility SubscriptionsVisibility => DopLesson ? Visibility.Visible : Visibility.Collapsed;
        public Visibility EmployeeVisibility => !DopLesson ? Visibility.Visible : Visibility.Collapsed;
        public bool DopLesson { get; set; }
        public List<Group> Groups { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Employee> Employees { get; set; }
        public List<SubscriptionTemplate> Subscriptions { get; set; }
        public Lesson Lesson { get; set; }
        public string Title { get; set; }

        #endregion

        #region Конструктор

        public SheduleChangeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Groups = Db.Groups.ToList();
            Rooms = Db.Rooms.ToList();
            Subscriptions = Db.Subscriptions.Include(x => x.Employee).ToList();
            Employees = Db.Employees.Include(x => x.Person).ToList();

            Messenger.Default.Register<string>(this, message =>
            {
                switch (message)
                {
                    case "UpdateGroups":
                        Groups = Db.Groups.ToList();
                        break;
                    case "UpdateRooms":
                        Rooms = Db.Rooms.ToList();
                        break;
                    case "UpdateSubscriptions":
                        Subscriptions = Db.Subscriptions.Include(x => x.Employee).ToList();
                        break;
                    case "UpdateEmployees":
                        Employees = Db.Employees.Include(x => x.Person).ToList();
                        break;
                }
            });

            Messenger.Default.Register<NotificationMessage<Lesson>>(this, message =>
            {
                if (message.Notification == "Add")
                {
                    Title = "Новое занятие";
                    Lesson = new Lesson();
                    AddVisibility = Visibility.Visible;
                    ChangeVisibility = Visibility.Collapsed;
                }
                else if (message.Notification == "Change")
                {
                    Lesson = message.Content;
                    Title = "Редактирование занятия";
                    DopLesson = message.Content.Tariff != null;
                    AddVisibility = Visibility.Collapsed;
                    ChangeVisibility = Visibility.Visible;
                }
            });

        }
        #endregion

        #region Команды
        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>(async (obj) =>
        {
            if (DopLesson)
            {
                Lesson.Employee = Lesson.Tariff.Employee;
                Lesson.Name = Lesson.Tariff.Name;
                Lesson.DateStart = Lesson.Tariff.Start;
                Lesson.DateEnd = Lesson.Tariff.End;
            }
            if ((DopLesson && (Db.Lessons.Where(x => x.Tariff == Lesson.Tariff && x.Group == Lesson.Group).Count() < Lesson.Tariff.HoursCount) || !DopLesson) &&
                Db.Lessons.FirstOrDefault(x => x.DayOfWeek == Lesson.DayOfWeek && x.Group == Lesson.Group && x.LessonNumber == Lesson.LessonNumber &&
                                ((Lesson.DateStart >= x.DateStart && Lesson.DateStart <= x.DateEnd) ||
                                (x.DateStart >= Lesson.DateStart && x.DateStart <= Lesson.DateEnd)) &&
                                ((Lesson.DateEnd >= x.DateStart && Lesson.DateEnd <= x.DateEnd) ||
                                (x.DateEnd >= Lesson.DateStart && x.DateEnd <= Lesson.DateEnd))) == null)
            {
                await Db.Lessons.AddAsync(Lesson);
                await Db.SaveChangesAsync();
                obj.DialogResult = true;
                Lesson = null;
                obj.Close();
                MessageService.Message("Success", "Занятие добавлено!");
            }
            else
            {
                MessageService.Message("Error", "Занятие пересекается с другим!");
            }
        });
        // Команда изменить
        public ICommand ChangeCommand => new RelayCommand<Window>(async (obj) =>
        {
            if (DopLesson)
            {
                Lesson.Employee = Lesson.Tariff.Employee;
                Lesson.Name = Lesson.Tariff.Name;
            }
            await Db.SaveChangesAsync();
            obj.DialogResult = true;
            Lesson = null;
            obj.Close();
            MessageService.Message("Success", "Занятие успешно изменено!");
        });
        // Команда удалить
        public ICommand RemoveCommand => new RelayCommand<Window>(async (obj) =>
        {
            Db.Lessons.Remove(Lesson);
            await Db.SaveChangesAsync();
            obj.DialogResult = true;
            Lesson = null;
            obj.Close();
            MessageService.Message("Success", "Занятие удалено!");
        });

        #endregion
    }
}
