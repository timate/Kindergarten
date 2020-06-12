using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views.ChangeViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class IncomeViewModel : ViewModelBase
    {
        #region Свойства

        public List<Transaction> Transactions { get; set; }
        public string Search { get; set; }
        private string Type { get; set; } = "Income";
        public DateTime Start { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime End { get; set; } = DateTime.Now;
        public bool IsTransactionsEmpty => Transactions.Count() == 0;
        public bool Cunsumption => Type == "Cunsumption";
        public bool FilterVisibility { get; set; }

        #endregion

        #region Конструктор

        public IncomeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Messenger.Default.Register<NotificationMessage>(this, message =>
            {
                if (message.Sender is FinancesViewModel)
                    Type = message.Notification;
                FilterVisibility = true;
                Update();
            });

            Messenger.Default.Register<NotificationMessage<DateTime[]>>(this, message =>
            {
                if (message.Sender is FinanceReportViewModel)
                {
                    Type = message.Notification;
                    Search = "";
                    Start = message.Content[0];
                    End = message.Content[1];
                    FilterVisibility = false;
                }
                Update();
            });
            Update();
        }

        #endregion

        #region Команды
        //Команда поиска
        public ICommand SearchCommand => new RelayCommand(() => Update());
        public ICommand Salary => new RelayCommand(async () =>
        {

            var Dialog = new SalaryChangeView();
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
            Update();
        });

        #endregion

        #region Методы

        void Update()
        {
            if (Type == "Income")
                Transactions = Db.Transactions.Include(x => x.Person).Where(x => x.Type).ToList();
            else if (Type == "Cunsumption")
                Transactions = Db.Transactions.Include(x => x.Person).Where(x => !x.Type).ToList();
            else Transactions = null;
            if (!string.IsNullOrWhiteSpace(Search))
                Transactions = Transactions.Where(x => (x.Person.Lastname + x.Person.Firstname + x.Person.Middlename).Contains(Search)).ToList();

            Transactions = Transactions.Where(x => x.DateProcess.DayOfYear >= Start.DayOfYear && x.DateProcess.DayOfYear <= End.DayOfYear).ToList();
        }

        #endregion
    }
}
