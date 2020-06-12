using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        #region Свойства
        private readonly CultureInfo Culture = new System.Globalization.CultureInfo("ru-RU");

        // Коллекция с занятиями
        public ObservableCollection<Lesson> Lessons { get; set; }
        // Коллекция с педагогами
        public List<Employee> Employees { get; set; }
        // Коллекция с группами
        public List<Group> Groups { get; set; }

        // Шкала дней
        public List<ScheduleTemplate> Template { get; set; }

        // Шкала времени
        public List<ScheduleTemplate> Times { get; set; } = new List<ScheduleTemplate>();

        public string Month { get; set; }

        // Выбранная дата
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        // Выбранный педагог
        public Employee SelectedEmployee { get; set; }
        // Выбранная группа
        public Group SelectedGroup { get; set; }

        public bool Today { get; set; }

        #endregion

        #region Команды

        public ICommand ChangeWeekCommand => new RelayCommand<string>(async (obj) =>
        {

            SelectedDate = obj == "Add" ? SelectedDate.AddDays(7) : SelectedDate.AddDays(-7);
            Month = Culture.DateTimeFormat.MonthNames[SelectedDate.Month - 1];

            await Task.Run(() =>
                {
                    UpdateSchedule();
                    UpdateLessons();
                });

        });

        public ICommand FilterCommand => new RelayCommand(async () =>
        {
            await Task.Run(() => UpdateLessons());
        });

        #endregion

        #region Конструктор
        public ScheduleViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Initialize();

            UpdateSchedule();

            UpdateLessons();

            Messenger.Default.Register<string>(this, message =>
            {
                switch (message)
                {
                    case "ScheduleTimesUpdate":
                        Initialize();
                        break;
                    case "UpdateGroups":
                        Groups = Db.Groups.ToList();
                        break;
                    case "UpdateEmployees":
                        Employees = Db.Employees.ToList();
                        break;
                }
            });
        }

        #endregion

        #region Методы

        /// <summary>
        /// Обновление занятии
        /// </summary>
        /// <param name="children"></param>
        void UpdateLessons(Children children = null)
        {
            // Вычисление дат начала и конца недели
            var StartWeek = SelectedDate.AddDays(1 - (int)SelectedDate.DayOfWeek);
            var EndWeek = SelectedDate.AddDays(6 - (int)SelectedDate.DayOfWeek);

            if (children == null)
            {
                Lessons = new ObservableCollection<Lesson>(Db.Lessons.Include(x=>x.Room)
                            .Where(x => StartWeek >= x.DateStart && StartWeek <= x.DateEnd &&
                                        EndWeek >= x.DateStart));
                if (SelectedGroup.Name != "Все")
                    Lessons = new ObservableCollection<Lesson>(Lessons.Where(x => x.Group == SelectedGroup));
                if (SelectedEmployee?.Person.Lastname != "Все")
                    Lessons = new ObservableCollection<Lesson>(Lessons.Where(x => x.Employee == SelectedEmployee).ToList());
            }
            else
                Lessons = new ObservableCollection<Lesson>(Db.Lessons.Include(x => x.Room)
                            .Where(x => (x.DateStart.DayOfYear >= StartWeek.DayOfYear && x.DateEnd.DayOfYear >= StartWeek.DayOfYear) &&
                                   children.ChildrenGroups.FirstOrDefault(y => y.Group == x.Group) != null).ToList());
        }

        /// <summary>
        /// Обновление дат
        /// </summary>
        void UpdateSchedule()
        {
            // Вычисление дат начала и конца недели
            var StartWeek = SelectedDate.AddDays(1 - (int)SelectedDate.DayOfWeek);
            var EndWeek = SelectedDate.AddDays(7 - (int)SelectedDate.DayOfWeek);
            Template = new List<ScheduleTemplate>();

            for (int i = 0; i < 6; i++)
            {
                var ShortName = Culture.DateTimeFormat.GetShortestDayName((DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(i + 1));
                var Days = StartWeek.AddDays(i).ToString("M", Culture);
                Template.Add(new ScheduleTemplate
                {
                    Title = $"{ShortName}, {Days}",
                    DayOfWeek = i + 1,
                    LessonNumber = 0
                });
            }

            Today = DateTime.Now.DayOfYear >= StartWeek.DayOfYear && DateTime.Now.DayOfYear <= EndWeek.DayOfYear;
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        void Initialize()
        {
            Employees = Db.Employees.Include(x=>x.Person).ToList();
            Groups = Db.Groups.ToList();
            SelectedGroup = Groups.FirstOrDefault();

            Month = Culture.DateTimeFormat.MonthNames[SelectedDate.Month - 1];

            var Time = Db.ScheduleTimes.FirstOrDefault();

            if (Time != null)
            {
                var Date = new DateTime(2020, 5, 3).AddHours(Time.WorkingHourStart);

                Times.Clear();
                //Добавление часов
                for (int i = 0; i < Time.WorkingHourEnd - Time.WorkingHourStart; i++)
                {
                    int turn;
                    if (i == 0)
                        turn = 0;
                    else if (i == Time.DinnerAfter)
                        turn = Time.DinnerDuration;
                    else if (i == Time.DinnerAfter + 1)
                        turn = Time.AfterDinnerTurnDuration;
                    else
                        turn = Time.TurnDuration;

                    var DateStart = Date.AddMinutes(turn);
                    Date = DateStart.AddMinutes(Time.LessonDuration);


                    Times.Add(new ScheduleTemplate
                    {
                        Title = $"{DateStart:HH:mm} - {Date:HH:mm}",
                        LessonNumber = i + 1,
                        DayOfWeek = 0,
                    });
                }
            }
            else
            {
                MessageService.Message("Info", "Настройте время.");
            }
        }

        #endregion

    }

    public class ScheduleTemplate
    {
        public string Title { get; set; }
        public int LessonNumber { get; set; }
        public int DayOfWeek { get; set; }
    }

}
