using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.ViewModels.Dialog;
using KinderGartenWpf.Views.ChangeViews;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class ChildrensViewModel : ViewModelBase
    {

        #region Свойства
        public bool IsChildrenEmpty { get => Childrens?.Count() == 0; }
        public bool ChangeBtnVisibility { get => SelectedItem != null && App.RoleId == 1; }
        public bool AddGroupBtnVisibility { get => SelectedGroup != null && App.RoleId == 1 && SelectedGroup.Name != "Все"; }
        public bool AddBtnVisibility { get => App.RoleId == 1; }
        public List<Children> Childrens { get; set; }
        public List<Group> Groups { get; set; }
        public Group SelectedGroup { get; set; }
        public string Search { get; set; }

        public Children SelectedItem { get; set; }

        #endregion

        #region Конструктор

        public ChildrensViewModel(KinderGartenDbContext db, MessageService messageService, NavigationService navigationService)
        {
            Db = db;
            MessageService = messageService;
            NavService = navigationService;
            Groups = Db.Groups.ToList();

            Messenger.Default.Register<NotificationMessage<Group>>(this, message =>
            {
                if (message.Sender is GroupsViewModel)
                {
                    if (message.Content != null)
                        SelectedGroup = Groups.FirstOrDefault(x => x == message.Content);
                }
            });

            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateGroups")
                    Groups = Db.Groups.ToList();
            });

            Messenger.Default.Register<NotificationMessage<Children>>(this, message =>
            {
                if (message.Sender is SingleDialogViewModel)
                {
                    if(message.Content != null && Db.ChildrenGroups.FirstOrDefault(x=>x.Children == message.Content && x.Group == SelectedGroup) == null) { 
                        Db.ChildrenGroups.Add(new ChildrenGroup { Children = message.Content, Group = SelectedGroup });
                        Db.SaveChanges();
                        MessageService.Message("Success", "Ребенок добавлен в группу!");
                        Update();
                    }
                }
            });

            Update();
            MessageService.Message("Info", "Чтобы посмотреть подробную информацию, дважды щелкните по ученику");
        }

        #endregion

        #region Команды
        //Команда поиска
        public ICommand SearchCommand => new RelayCommand(() => Update());

        //Команда добавить
        public ICommand ChildrenAdd => new RelayCommand(() =>
        {
            var Dialog = new ChildrenChangeView();
            Messenger.Default.Send(new NotificationMessage<Children>(this, null, "Add"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        //Команда для просмотра подробной информации
        public ICommand GridDoubleCommand => new RelayCommand(() =>
        {
            NavService.Navigate("Children");
            Messenger.Default.Send(new NotificationMessage<Children>(this, SelectedItem, "Details"));
        });

        // Команда изменить
        public ICommand ChildrenChange => new RelayCommand(() =>
        {
            var Dialog = new ChildrenChangeView();
            Messenger.Default.Send(new NotificationMessage<Children>(this, SelectedItem, "Change"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        public ICommand AddGroupChildren => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, dialog.DataContext, SelectedGroup.Name, "Название"));
            dialog.ShowDialog();
        });

        #endregion

        #region Методы

        /// <summary>
        /// Обновление таблицы учеников
        /// </summary>
        void Update()
        {
            Task.Run(() =>
            {

                if (string.IsNullOrWhiteSpace(Search))

                    Childrens = Db.Childrens
                                        .Include(x => x.Person)
                                        .Include(x => x.ChildrenSubscriptions)
                                            .ThenInclude(x => x.Subscription)
                                        .Include(x => x.ChildrenGroups)
                                            .ThenInclude(x => x.Group)
                                             .ToList();

                else
                    Childrens = Db.Childrens.Include(x => x.Person).Include(x => x.ChildrenSubscriptions).ThenInclude(x => x.Subscription).Include(x => x.ChildrenGroups).ThenInclude(x => x.Group)
                                  .Where(x => x.Person.Firstname.Contains(Search)
                                             || x.Person.Lastname.Contains(Search)
                                             || x.Person.Middlename.Contains(Search)
                                             || x.Person.Phone.Contains(Search))
                                  .ToList();
                if (SelectedGroup != null && SelectedGroup.Name != "Все")
                    Childrens = Childrens.Where(x => x.ChildrenGroups.FirstOrDefault(x => x.Group == SelectedGroup) != null).ToList();
            });
        }

        #endregion

    }
}
