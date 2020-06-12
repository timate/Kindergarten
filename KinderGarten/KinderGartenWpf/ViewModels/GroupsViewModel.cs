using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.ViewModels.Dialog;
using KinderGartenWpf.Views.ChangeViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class GroupsViewModel : ViewModelBase
    {
        #region Свойства
        public bool IsGroupEmpty { get => Groups.Count() == 0; }
        public bool ChangeBtnVisibility { get => SelectedGroup != null; }
        public List<Group> Groups { get; set; }
        public Group SelectedGroup { get; set; }

        #endregion

        #region Конструктор

        public GroupsViewModel(KinderGartenDbContext db, NavigationService navService, MessageService messageService)
        {
            Db = db;
            NavService = navService;
            MessageService = messageService;
            Messenger.Default.Register<NotificationMessage<string>>(this, message =>
            {
                if (message.Sender is SingleDialogViewModel)
                {
                    if (message.Content == "Новая группа")
                    {
                        Db.Groups.Add(new Group { Name = message.Notification });
                    }
                    if (message.Content == "Редактирование группы")
                    {
                        var temp = Db.Groups.FirstOrDefault(x => x == SelectedGroup);
                        temp.Name = message.Content;
                    }
                    Db.SaveChanges();
                }
            });

            Update();
        }

        #endregion

        #region Команды

        //Команда добавить
        public ICommand AddCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, dialog.DataContext, "Новая группа", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                Update();
                MessageService.Message("Success", "Группа добавлена!");
                Messenger.Default.Send("UpdateGroups");
            }
        });

        //Команда для просмотра подробной информации
        public ICommand GridDoubleCommand => new RelayCommand<Group>((group) =>
        {
            Messenger.Default.Send(new NotificationMessage<Group>(this, group, "Details"));
            NavService.Navigate("Childrens");
        });

        // Команда изменить
        public ICommand ChangeCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, "Редктирование группы", "Название"));
            dialog.ShowDialog();
            Messenger.Default.Send("UpdateGroups");
        });

        // Команда удалить
        public ICommand RemoveCommand => new RelayCommand(() =>
        {
            var childrens = Db.ChildrenGroups.Where(x => x.Group == SelectedGroup).ToList();
            Db.ChildrenGroups.RemoveRange(childrens);
            Db.Groups.Remove(SelectedGroup);
            Messenger.Default.Send("UpdateGroups");
        });

        #endregion

        #region Методы

        /// <summary>
        /// Обновление таблицы учеников
        /// </summary>
        void Update()
        {
            Groups = Db.Groups.ToList();
        }

        #endregion
    }
}
