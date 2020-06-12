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
    public class ParentChangeViewModel : DialogViewModel
    {
        #region Свойства
        public bool AddVisibility { get; set; }
        public bool ChangeVisibility { get; set; }
        public Parent Parent { get; set; }
        public List<ParentRole> ParentRoles { get; set; }
        public int ChildrenId { get; set; }
        public string Title { get; set; }

        #endregion

        #region Конструктор

        public ParentChangeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;
            ParentRoles = Db.ParentRoles.ToList();
            Messenger.Default.Register<NotificationMessage<Parent>>(this, message =>
            {
                if (message.Sender is ParentsViewModel)
                {
                    if (message.Notification == "Change")
                    {
                        Parent = message.Content;
                        Title = "Редактирование родителя";
                        AddVisibility = false;
                        ChangeVisibility = true;
                    }
                    else
                    {
                        Title = "Новый родитель";
                        Parent = new Parent()
                        {
                            Person = new Person()
                        };
                        ChildrenId = int.Parse(message.Notification);
                        AddVisibility = true;
                        ChangeVisibility = false;
                    }
                }
            });
            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateParentRoles")
                    ParentRoles = Db.ParentRoles.ToList();
            });
        }
        #endregion

        #region Команды
        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>((obj) =>
        {
            Parent.Children = Db.Childrens.FirstOrDefault(x => x.Id == ChildrenId);
            Db.Parents.Add(Parent);
            Db.SaveChanges();
            obj.DialogResult = true;
            Parent = null;
            obj.Close();
            MessageService.Message("Success", "Родитель добавлен");
        });
        // Команда изменить
        public ICommand ChangeCommand => new RelayCommand<Window>(async (obj) =>
        {
            await Db.SaveChangesAsync();
            obj.DialogResult = true;
            Parent = null;
            obj.Close();
            MessageService.Message("Success", "Данные изменены");
        });
        // Команда удалить
        public ICommand RemoveCommand => new RelayCommand<Window>(async (obj) =>
        {
            Db.Parents.Remove(Parent);
            await Db.SaveChangesAsync();
            obj.DialogResult = true;
            Parent = null;
            obj.Close();
            MessageService.Message("Success", "Родитель удален");
        });



        #endregion
    }
}
