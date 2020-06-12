using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class CabinetViewModel : ViewModelBase
    {
        #region Свойства
        public Page TabView { get; set; } = new EmployeeChangeView();
        public Employee User { get; set; }
        public bool ChangeBtnVisibility { get => App.RoleId == 1 || App.UserId == User?.Id; }


        #endregion

        #region Команды

        public ICommand ChangeTabCommand => new RelayCommand<string>((numb) =>
        {
            switch (int.Parse(numb))
            {
                case 6:
                    TabView = new EmployeeChangeView();
                    break;
                case 5:
                    TabView = new SuccessLessonsView();
                    break;
                case 4:
                    TabView = new BidsView();
                    break;
                default:
                    MessageBox.Show("Что-то пошло не так!");
                    break;
            }
            Messenger.Default.Send(new NotificationMessage<Employee>(User, null));
        });

        #endregion

        #region Конструктор

        public CabinetViewModel(KinderGartenDbContext db)
        {
            Db = db;

            User = Db.Employees.Find(App.UserId);

            Messenger.Default.Register<NotificationMessage<Employee>>(this, message =>
            {
                User = message.Content;
            });
        }

        #endregion
    }
}
