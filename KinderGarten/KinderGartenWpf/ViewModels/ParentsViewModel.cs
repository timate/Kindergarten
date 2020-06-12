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
    public class ParentsViewModel : ViewModelBase
    {
        #region Свойства
        public int ChildrenId { get; set; }
        public List<Parent> Parents { get; set; }
        public Parent SelectedItem { get; set; }
        public bool GridEmptyVisibility { get => Parents?.Count() == 0; }
        public bool ChangeBtnVisibility { get => SelectedItem != null && App.RoleId == 1; }
        public bool AddBtnVisibility { get => App.RoleId == 1; }

        #endregion

        #region Конструктор

        public ParentsViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;
            Messenger.Default.Register<NotificationMessage<Children>>(this, message =>
            {
                if (message.Sender is ChildrenViewModel)
                {
                    ChildrenId = message.Content.Id;
                    Update();
                }
            });
        }

        #endregion

        #region Команды

        //Команда добавить
        public ICommand AddCommand => new RelayCommand(() =>
        {
            var Dialog = new ParentChangeView();
            Messenger.Default.Send(new NotificationMessage<Parent>(this, null, ChildrenId.ToString()));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        public ICommand ChangeCommand => new RelayCommand(() =>
        {
            var Dialog = new ParentChangeView();
            Messenger.Default.Send(new NotificationMessage<Parent>(this, SelectedItem, "Change"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        #endregion

        #region Методы

        /// <summary>
        /// Обновляет таблицу педагогов
        /// </summary>
        void Update()
        {
            Parents = Db.Parents.Include(x => x.Person)
                                .Include(x => x.ParentRole)
                                .Where(x => x.Children.Id == ChildrenId).ToList();
        }

        #endregion
    }
}
