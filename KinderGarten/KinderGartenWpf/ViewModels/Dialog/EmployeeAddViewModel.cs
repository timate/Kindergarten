using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Dialog
{
    public class EmployeeAddViewModel : DialogViewModel
    {
        #region Свойства
        private readonly AuthenticationService AuthService;
        public Visibility AddVisibility { get; set; }
        public Visibility ChangeVisibility { get; set; }
        public Employee Employee { get; set; }
        public string Title { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<Role> Roles { get => Db.Roles.ToList(); }

        #endregion

        #region Конструктор

        public EmployeeAddViewModel(KinderGartenDbContext db, AuthenticationService authService, MessageService messageService)
        {
            Db = db;
            AuthService = authService;
            MessageService = messageService;

            Messenger.Default.Register<NotificationMessage<Employee>>(this, message =>
            {
                if (message.Sender is EmployeesViewModel)
                {
                    Title = "Новый сотрудник";
                    Employee = new Employee
                    {
                        Document = new Document(),
                        Person = new Person()
                    };

                    AddVisibility = Visibility.Visible;
                    ChangeVisibility = Visibility.Collapsed;
                }
            });
        }
        #endregion

        #region Команды

        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>(async (obj) =>
        {
            if (Db.Users.FirstOrDefault(x => x.Login == Login) is null)
                if (Password == ConfirmPassword)
                {
                    try
                    {
                        Employee.User = AuthService.Reg(Login, Password);
                        await Db.Employees.AddAsync(Employee);
                        await Db.SaveChangesAsync();
                        obj.DialogResult = true;
                        Login = string.Empty;
                        Password = string.Empty;
                        ConfirmPassword = string.Empty;
                        Employee = null;
                        obj.Close();
                        MessageService.Message("Success", "Сотрудник добавлен!");
                        Messenger.Default.Send("UpdateEmployees");
                    }
                    catch
                    {
                        MessageService.Message("Error", "Заполните обязательные поля!");
                    }
                }
                else
                    MessageService.Message("Error", "Пароли не совпадают!");
            else
                MessageService.Message("Error", "Пользователь с таким логином уже существует!");
        });

        public ICommand PhotoChangeCommand => new RelayCommand(() =>
        {
            OpenFileDialog dlg = new OpenFileDialog();
            ImageConverter imageConverter = new ImageConverter();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
                Employee.Person.Image = (byte[])imageConverter.ConvertTo(System.Drawing.Image.FromFile(dlg.FileName), typeof(byte[]));
        });

        #endregion
    }
}
