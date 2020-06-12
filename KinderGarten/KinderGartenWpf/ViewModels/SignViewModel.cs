using GalaSoft.MvvmLight.Command;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class SignViewModel : DialogViewModel
    {

        #region Свойства

        private readonly AuthenticationService AuthService;
        public bool IsAnimating { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        private Employee User { get; set; }
        #endregion

        #region Конструктор
        public SignViewModel(AuthenticationService authService)
        {
            AuthService = authService;
        }
        #endregion

        #region Команды

        // Команда для авторизации
        public ICommand SignCommand => new RelayCommand<Window>(async (obj) =>
        {
            IsAnimating = true;

            await Task.Run(async () =>
            {
                User = await AuthService.Auth(Login, Password);
            });

            if (User != null)
            {
                var window = new ShellView();
                IsAnimating = false;
                App.UserId = User.Id;
                App.RoleId = User.Role.Id;
                window.Show();
                obj.Close();
            }
            else
            {
                IsAnimating = false;
                Message = "Неверный логин или пароль!";
                await Task.Delay(5000);
                Message = "";
            }

        }, obj => !IsAnimating);

        #endregion

        #region Методы



        #endregion
    }
}
