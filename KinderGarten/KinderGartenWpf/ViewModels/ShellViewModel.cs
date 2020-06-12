using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {

        #region Свойства
        public bool MenuOpen { get; set; } = false;
        public Visibility MenuVisible { get; set; }
        public Visibility MinimizeVisible { get; set; }
        public Visibility MaximizeVisible { get; set; }
        public Visibility CloseVisible { get; set; }

        public bool CanGoBack { get; set; }

        public WindowState WindowState { get; set; } = WindowState.Normal;
        public ResizeMode WindowResize { get; set; } = ResizeMode.CanResize;

        public int WindowWidth { get; set; } = 800;

        public Employee Employee { get => Db?.Employees.Find(App.UserId); }
        public int WindowHeight { get; set; } = 500;
        public Visibility WindowVisible { get; set; } = Visibility.Visible;
        public string UserName { get => $"{Employee?.Person?.Lastname} {Employee?.Person?.Firstname[0]}. {Employee?.Person?.Middlename[0]}."; }

        public bool EmployeesVisibility { get => App.RoleId == 1 || App.RoleId == 2; }
        public bool SettingsVisibility { get => App.RoleId == 1; }
        public bool FinancesVisibility { get => App.RoleId == 1; }

        #endregion

        #region Команды

        // Команда свернуть окно
        public ICommand MinimizeCommand => new RelayCommand<Window>((obj) => obj.WindowState = WindowState.Minimized);

        // Комнда развернуть окно
        public ICommand MaximizeCommand => new RelayCommand<Window>((obj) => obj.WindowState = obj.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);

        // Команда закрыть окно
        public ICommand CloseCommand => new RelayCommand<Window>((obj) => obj.Close());

        // Команда перетаскивания окна
        public ICommand WindowDragCommand => new RelayCommand<Window>((obj) => obj.DragMove());

        // Команда открыть/закрыть меню
        public ICommand SignOutCommand => new RelayCommand<Window>((obj) =>
        {
            new SignView().Show(); obj.Close();
        });
        // Команда для перехода в личный кабинет
        public ICommand CabinetCommand => new RelayCommand(() =>
        {
            NavService.Navigate("Cabinet");
            Messenger.Default.Send(new NotificationMessage<Employee>(this, Employee, "CurrentUser"));
        });
        // Команда назад
        public ICommand BackCommand => new RelayCommand(() =>
        {
            NavService.Back();
        }, () => CanGoBack);
        // Команда для меню
        public ICommand MenuCommand => new RelayCommand<string>((i) =>
        {
            switch (int.Parse(i))
            {
                case 1:
                    MenuOpen = !MenuOpen;
                    break;
                case 3:
                    NavService.Navigate("Main");
                    break;
                case 4:
                    NavService.Navigate("Schedule");
                    break;
                case 5:
                    NavService.Navigate("Childrens");
                    break;
                case 6:
                    NavService.Navigate("Employees");
                    break;
                case 7:
                    NavService.Navigate("Visits");
                    break;
                case 8:
                    NavService.Navigate("Settings");
                    break;
                case 9:
                    NavService.Navigate("Finances");
                    break;
                case 10:
                    NavService.Navigate("Analytics");
                    break;
            };

        });

        #endregion

        #region Конструктор

        public ShellViewModel(NavigationService navService, KinderGartenDbContext db)
        {
            NavService = navService;

            Db = db;
            Messenger.Default.Register<bool>(this, b => CanGoBack = b);

            Initialize();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Инициализация главного окна
        /// </summary>
        private void Initialize()
        {
            WindowVisible = Visibility.Hidden;
            NavService.Navigate("Cabinet");
            WindowHeight = 600;
            WindowWidth = 800;
            WindowState = WindowState.Maximized;
            MenuVisible = Visibility.Visible;
            MenuOpen = false;
            MinimizeVisible = Visibility.Visible;
            MaximizeVisible = Visibility.Visible;
            WindowResize = ResizeMode.CanResize;

            WindowVisible = Visibility.Visible;
        }

        #endregion

    }
}
