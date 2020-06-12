using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using KinderGartenWpf.Views.ChangeViews;
using System.Windows.Controls;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class ChildrenViewModel : ViewModelBase
    {
        #region Свойства
        public Page TabView { get; set; } = new SubscriptionView();

        public Children Children { get; set; }
        public string ChildrenName { get; set; }
        public string ChildrenGroups { get; set; }

        #endregion

        #region Конструктор
        public ChildrenViewModel()
        {
            Messenger.Default.Register<NotificationMessage<Children>>(this, message =>
            {
                Children = message.Content;

                if (Children != null)
                    ChildrenName = $"{Children.Person.Lastname} {Children.Person.Firstname} {Children.Person.Middlename}";

                /*foreach (ChildrenGroup group in message.Children.ChildrenGroups)
                    ChildrenGroups += group.Group.Name+" ";*/
            });
        }
        #endregion

        #region Команды

        public ICommand ChangeTabCommand => new RelayCommand<string>((numb) =>
        {
            switch (int.Parse(numb))
            {
                case 1:
                    TabView = new SubscriptionView();
                    Messenger.Default.Send(new NotificationMessage<Children>(this, Children, null));
                    break;
                case 2:
                    TabView = new ScheduleView();
                    Messenger.Default.Send(new NotificationMessage<Children>(this, Children, null));
                    break;
                case 3:
                    TabView = new ParentsView();
                    Messenger.Default.Send(new NotificationMessage<Children>(this, Children, null));
                    break;
            }
        });

        public ICommand ChangeCommand => new RelayCommand(() =>
        {
            var Dialog = new ChildrenChangeView();
            Messenger.Default.Send(new NotificationMessage<Children>(this, Children, "Change"));
            Dialog.ShowDialog();
        });

        #endregion

        #region Методы

        #endregion
    }
}
