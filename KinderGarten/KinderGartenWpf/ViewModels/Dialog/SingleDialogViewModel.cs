using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Dialog
{
    public class SingleDialogViewModel : DialogViewModel
    {
        #region Свойства
        public string Name { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public Visibility TextVisibility { get; set; }
        public Visibility ComboVisibility { get => TextVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed; }
        public List<Children> Childrens { get; set; }
        public Children Children { get; set; }
        private object Target { get; set; }
        #endregion

        #region Команды
        public ICommand OkCommand => new RelayCommand<System.Windows.Window>((window) =>
        {
            window.DialogResult = true;
            if (Target is ChildrensViewModel)
            {
                if (Children != null)
                    Messenger.Default.Send(new NotificationMessage<Children>(this, Target, Children, Text));
                else
                    MessageService.Message("Error", "Выберите ученика");
            }
            else
                Messenger.Default.Send(new NotificationMessage<string>(this, Target, Title, Text));
        });
        #endregion

        #region Конструктор
        public SingleDialogViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;
            Messenger.Default.Register<NotificationMessage<string>>(this, message =>
            {
                if (message.Sender is ChildrensViewModel)
                {
                    Title = "Добавление ученика";
                    Childrens = Db.Childrens.Where(x=>x.ChildrenGroups.FirstOrDefault(x=>x.Group.Name == message.Content) == null).ToList();
                    Target = message.Sender;
                    TextVisibility = Visibility.Collapsed;
                }
                else
                {
                    Target = message.Sender;
                    Title = message.Content;
                    Name = message.Notification;
                }
            });
        }
        #endregion
    }
}
