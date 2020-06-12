

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class SuccessLessonsViewModel : ViewModelBase
    {
        #region Свойства

        public Employee Employee { get; set; }
        public List<Visit> SuccessLessons { get; set; }
        public DateTime Start { get; set; } = DateTime.Now.AddDays(-10);
        public DateTime End { get; set; } = DateTime.Now;
        public string Search { get; set; }
        public bool EmptyVisibility { get => SuccessLessons.Count() == 0; }

        #endregion

        #region Конструктор

        public SuccessLessonsViewModel(KinderGartenDbContext db)
        {
            Db = db;

            Messenger.Default.Register<NotificationMessage<Employee>>(this, message =>
            {
                Employee = message.Content;
                Update();
            });

            Update();
        }

        #endregion

        #region Команды

        public ICommand ViewCommand => new RelayCommand(() => Update());

        #endregion

        #region Методы

        void Update()
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                SuccessLessons = Db.Visits.Include(x => x.Lesson)
                                             .ThenInclude(x => x.Group)
                                           .Where(x => x.Lesson.Employee == Employee && x.Date <= DateTime.Now &&
                                                       x.Date >= Start && x.Date <= End).ToList();
            }
            else
            {
                SuccessLessons = Db.Visits.Include(x => x.Lesson)
                                             .ThenInclude(x => x.Group)
                                           .Where(x => x.Lesson.Employee == Employee && x.Date <= DateTime.Now &&
                                                       x.Date >= Start && x.Date <= End &&
                                                       x.Lesson.Name.Contains(Search)).ToList();
            }
        }

        #endregion
    }
}
