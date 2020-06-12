using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views.ChangeViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class SubscriptionViewModel : ViewModelBase
    {
        #region Свойства
        public bool GridEmptyVisibility { get => Subscriptions?.Count() == 0; }
        public bool AddBtnVisibility { get => App.RoleId == 0 || App.RoleId == 1; }
        public bool RemoveBtnVisibility { get => SelectedItem != null && (App.RoleId == 0 || App.RoleId == 1); }
        public List<ChildrenSubscription> Subscriptions { get; set; }
        public Children Children { get; set; }
        public SubscriptionTemplate SelectedItem { get; set; }

        #endregion

        #region Конструктор

        public SubscriptionViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Messenger.Default.Register<NotificationMessage<Children>>(this, message =>
            {
                if (message.Sender is ChildrensViewModel)
                {
                    if (message.Notification == "Details")
                    {
                        Children = message.Content;
                        Update();
                    }
                }
            });

            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateSubscriptions")
                    Update();
            });
            Update();
        }

        #endregion

        #region Команды

        //Команда добавить
        public ICommand AddCommand => new RelayCommand(() =>
        {

            var Dialog = new SubscriptionChangeView();
            Messenger.Default.Send(new NotificationMessage<Children>(this, Dialog.DataContext, Children, "Add"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        public ICommand RemoveCommand => new RelayCommand(async () =>
        {
            var cs = Db.Childrens.Find(Children).ChildrenSubscriptions.FirstOrDefault(x => x.Subscription == SelectedItem);
            cs.Subscription = null;
            cs.Children = null;
            await Db.SaveChangesAsync();
            MessageService.Message("Success", "Абонемент удален!");
            Update();
        });

        #endregion

        #region Методы

        void Update()
        {
            Subscriptions = Db.ChildrenSubscriptions.Where(x => x.Children == Children).ToList();
        }

        #endregion
    }
}
