using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Dialog
{
    public class SubscriptionChangeViewModel : DialogViewModel
    {
        #region Свойства
        public Visibility AddVisibility { get; set; }
        public Visibility ChangeVisibility { get; set; }
        public List<SubscriptionTemplate> Subscriptions { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public PaymentMethod SelectedMethod { get; set; }
        public SubscriptionTemplate SelectedItem { get; set; }
        public Children Children { get; set; }
        public string Title { get; set; }
        public decimal Price { get => SelectedItem != null ? SelectedItem.Amount * SelectedItem.HoursCount : 0; }
        #endregion

        #region Конструктор

        public SubscriptionChangeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Subscriptions = Db.Subscriptions.ToList();
            PaymentMethods = Db.PaymentMethods.ToList();

            Messenger.Default.Register<string>(this, message =>
            {
                switch (message)
                {
                    case "UpdateSubscriptions":
                        Subscriptions = Db.Subscriptions.ToList();
                        break;
                    case "UpdatePaymentMethods":
                        PaymentMethods = Db.PaymentMethods.ToList();
                        break;
                }
            });

            Messenger.Default.Register<NotificationMessage<Children>>(this, message =>
            {
                if (message.Notification == "Add")
                {
                    Title = "Оформление абонемента";
                    Children = message.Content;
                    AddVisibility = Visibility.Visible;
                    ChangeVisibility = Visibility.Collapsed;
                }
            });

        }
        #endregion

        #region Команды
        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>((obj) =>
        {
            if (Children != null) { 
            Db.ChildrenSubscriptions.Add(new ChildrenSubscription { Children = Children, Subscription = SelectedItem });
                Db.Transactions.Add(new Transaction
                {
                    Amount = Price,
                    Comment = "Покупка абонемента",
                    DateProcess = DateTime.Now,
                    Payment = true,
                    Person = Children.Person,
                    Type = true,
                    PaymentMethod = SelectedMethod
                });
                Db.SaveChanges();
            obj.DialogResult = true;
            obj.Close();
            MessageService.Message("Success", "Абонемент оформлен!");
            }
        });

        #endregion
    }
}
