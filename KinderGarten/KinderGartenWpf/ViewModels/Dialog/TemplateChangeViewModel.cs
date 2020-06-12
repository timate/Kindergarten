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
    public class TemplateChangeViewModel : DialogViewModel
    {

        #region Свойства
        public Visibility AddVisibility { get; set; }
        public Visibility ChangeVisibility { get; set; }
        public SubscriptionTemplate Subscription { get; set; }
        public List<Employee> Employees { get; set; }
        public string Title { get; set; }

        #endregion

        #region Конструктор

        public TemplateChangeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Employees = Db.Employees.Include(x => x.Person).ToList();

            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateEmployees")
                {
                    Employees = Db.Employees.Include(x => x.Person).ToList();
                }
            });

            Messenger.Default.Register<NotificationMessage<SubscriptionTemplate>>(this, message =>
            {
                if (message.Notification == "Add")
                {
                    Title = "Новый шаблон";
                    Subscription = new SubscriptionTemplate();
                    AddVisibility = Visibility.Visible;
                    ChangeVisibility = Visibility.Collapsed;
                }
                else if (message.Notification == "Change")
                {
                    Subscription = message.Content;
                    Title = "Редактирование шаблона";
                    AddVisibility = Visibility.Collapsed;
                    ChangeVisibility = Visibility.Visible;
                }
            });

        }
        #endregion

        #region Команды
        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>((obj) =>
        {
            Db.Subscriptions.Add(Subscription);
            Db.SaveChanges();
            obj.DialogResult = true;
            Subscription = null;
            obj.Close();
            MessageService.Message("Success", "Шаблон добавлен!");
            Messenger.Default.Send("UpdateSubscriptions");
        });
        // Команда изменить
        public ICommand ChangeCommand => new RelayCommand<Window>((obj) =>
        {
            Db.SaveChanges();
            obj.DialogResult = true;
            Subscription = null;
            obj.Close();
            MessageService.Message("Success", "Данные успешно изменены!");
            Messenger.Default.Send("UpdateSubscriptions");
        });
        // Команда удалить
        public ICommand RemoveCommand => new RelayCommand<Window>((obj) =>
        {
            Db.Subscriptions.Remove(Subscription);
            Db.SaveChanges();
            obj.DialogResult = true;
            Subscription = null;
            obj.Close();
            MessageService.Message("Success", "Шаблон удален!");
            Messenger.Default.Send("UpdateSubscriptions");
        });

        #endregion

    }
}
