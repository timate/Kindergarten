using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views.ChangeViews;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class SubscriptionTemplatesViewModel : ViewModelBase
    {

        #region Свойства
        public bool ChangeBtnVisibility { get => SelectedItem != null; }
        public List<SubscriptionTemplate> Subscriptions { get; set; }
        public SubscriptionTemplate SelectedItem { get; set; }

        public bool GridEmptyVisibility { get => Subscriptions?.Count() == 0; }

        #endregion

        #region Команды

        public ICommand AddCommand => new RelayCommand(() =>
        {
            var Dialog = new SubscriptionTemplateChangeView();
            Messenger.Default.Send(new NotificationMessage<SubscriptionTemplate>(null, "Add"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
            MessageService.Message("Success", "Шаблон добавлен");
        });

        public ICommand ChangeCommand => new RelayCommand(() =>
        {
            var Dialog = new SubscriptionTemplateChangeView();
            Messenger.Default.Send(new NotificationMessage<SubscriptionTemplate>(this, SelectedItem, "Change"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        public ICommand RemoveCommand => new RelayCommand(async () =>
        {
            Db.Remove(SelectedItem);
            await Db.SaveChangesAsync();
            Update();
            MessageService.Message("Success", "Шаблон удален");
        });

        #endregion

        #region Конструктор

        public SubscriptionTemplatesViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;
            Update();
            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateSubscriptions")
                    Update();
            });
        }

        #endregion

        #region Методы

        void Update()
        {
            Subscriptions = Db.Subscriptions.Include(x => x.Employee).ThenInclude(x => x.Person).ToList();
        }

        #endregion
    }
}
