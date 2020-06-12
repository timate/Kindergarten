using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views.Dialog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class VisitsViewModel : ViewModelBase
    {
        #region Свойства
        public List<Lesson> Lessons { get; set; }
        public List<Visit> Visits { get; set; }
        public bool VisitsEmpty { get; set; } = false;
        public bool AddBtnVisibility { get => App.RoleId == 1 || App.RoleId == 2; }
        public bool ChangeBtnVisibility { get => App.RoleId == 1 || App.RoleId == 2; }
        public List<VisitStatus> VisitStatuses { get; set; }
        public List<Group> Groups { get; set; }
        public List<Employee> Emplyees { get; set; }

        private Lesson _selectedItem;
        public Lesson SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged();
                    if (value != null)
                        SetVisits();
                }
            }
        }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    RaisePropertyChanged();
                    Visits = null;
                    SelectedItem = null;
                    Update();
                }
            }
        }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                    RaisePropertyChanged();
                    Update();
                }
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    RaisePropertyChanged();
                    Update();
                }
            }
        }

        public bool EmptyVisibility { get => SelectedItem == null; }
        public bool DetailVisibility { get => SelectedItem != null; }

        #endregion

        #region Команды

        public ICommand AddCommand => new RelayCommand(() =>
        {
            var Dialog = new SheduleChangeView();
            Messenger.Default.Send(new NotificationMessage<Lesson>(this, null, "Add"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        public ICommand ChangeCommand => new RelayCommand(() =>
        {
            var Dialog = new SheduleChangeView();
            Messenger.Default.Send(new NotificationMessage<Lesson>(this, SelectedItem, "Change"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        public ICommand RemoveCommand => new RelayCommand(async () =>
        {
            Db.Lessons.Remove(SelectedItem);
            Lessons.Remove(SelectedItem);
            await Db.SaveChangesAsync();
            MessageService.Message("Success", "Занятие удалено!");
        });

        public ICommand SaveCommand => new RelayCommand(async () =>
        {
            if (VisitsEmpty)
                await Db.Visits.AddRangeAsync(Visits);
            else
                Db.Visits.UpdateRange(Visits);
            await Db.SaveChangesAsync();
            MessageService.Message("Success", "Посещения сохранены!");
        });

        #endregion

        #region Конструктор

        public VisitsViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            VisitStatuses = Db.VisitStatus.ToList();
            Groups = Db.Groups.ToList();
            Emplyees = Db.Employees.ToList();

            Messenger.Default.Register<string>(this, message =>
            {
                switch (message)
                {
                    case "UpdateVisitStatuses":
                        VisitStatuses = Db.VisitStatus.ToList();
                        break;
                    case "UpdateGroups":
                        Groups = Db.Groups.ToList();
                        break;
                    case "UpdateEmployees":
                        Emplyees = Db.Employees.ToList();
                        break;
                }
            });

            Update();

        }

        #endregion

        #region Методы

        void Update()
        {
            //Если воспитатель или педагог не выбран
            if (SelectedEmployee is null)
                Lessons = Db.Lessons
                            .Include(x => x.Room)
                            .Include(x => x.Employee)
                            .Include(x => x.Group)
                            .Where(x => x.DayOfWeek == (int)SelectedDate.DayOfWeek && x.Group == SelectedGroup &&
                                        SelectedDate.DayOfYear >= x.DateStart.DayOfYear && SelectedDate <= x.DateEnd).ToList();
            else
                Lessons = Db.Lessons
                            .Include(x => x.Room)
                            .Include(x => x.Employee)
                            .Include(x => x.Group)
                            .Where(x => x.DayOfWeek == (int)SelectedDate.DayOfWeek && x.Group == SelectedGroup &&
                                                        x.Employee.Id == SelectedEmployee.Id &&
                                           SelectedDate.DayOfYear >= x.DateStart.DayOfYear && SelectedDate <= x.DateEnd).ToList();
        }

        void SetVisits()
        {
            if (Db.Visits.Where(x => x.Lesson == SelectedItem && x.Date == SelectedDate).Count() == 0)
            {
                Visits = new List<Visit>();
                var ChildrenGroups = Db.ChildrenGroups.Include(x => x.Children).ThenInclude(x => x.Person).Where(x => x.Group == SelectedItem.Group).ToList();
                foreach (ChildrenGroup i in ChildrenGroups)
                {
                    Visits.Add(new Visit()
                    {
                        Children = i.Children,
                        Lesson = SelectedItem,
                        Date = SelectedDate,
                    });
                }
                VisitsEmpty = true;
            }
            else
            {
                VisitsEmpty = false;
                Visits = Db.Visits
                           .Include(x => x.Children).ThenInclude(x => x.Person)
                           .Include(x => x.VisitStatus)
                           .Where(x => x.Lesson == SelectedItem).ToList();
            }
        }

        #endregion
    }
}
