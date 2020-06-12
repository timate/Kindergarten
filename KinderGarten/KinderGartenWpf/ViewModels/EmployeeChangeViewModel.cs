using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class EmployeeChangeViewModel : ViewModelBase
    {

        #region Свойства
        private readonly AuthenticationService AuthService;
        public Employee Employee { get; set; }
        public List<Group> Groups { get; set; }
        public List<Role> Roles { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool PropertyEnable { get => App.RoleId == 1; }
        #endregion

        #region Конструктор
        public EmployeeChangeViewModel(KinderGartenDbContext db, AuthenticationService authService, MessageService messageService)
        {
            Db = db;
            AuthService = authService;
            MessageService = messageService;

            Groups = Db.Groups.ToList();
            Roles = Db.Roles.ToList();

            Employee = Db.Employees.Find(App.UserId);

            Messenger.Default.Register<string>(this, message =>
            {
                switch (message)
                {
                    case "UpdateGroups":
                        Groups = Db.Groups.ToList();
                        break;
                    case "UpdateRoles":
                        Roles = Db.Roles.ToList();
                        break;
                }
            });

            Messenger.Default.Register<NotificationMessage<Employee>>(this, message =>
            {

                if (message.Sender is ShellViewModel || message.Sender is EmployeesViewModel)
                {
                    Employee = message.Content;

                }
            });

        }
        #endregion

        #region Команды
        // Команда изменить основные данные
        public ICommand ChangeMainCommand => new RelayCommand(async () =>
        {
            try
            {
                var user = await Db.Employees.FirstOrDefaultAsync(x => x.Id == Employee.Id);
                user = Employee;
                await Db.SaveChangesAsync();
                UpdateUser();
                MessageService.Message("Success", "Общие данные сохранены!");
                Messenger.Default.Send("UpdateEmployees");
            }
            catch
            {

            }
        });
        // Команда изменить документ педагога
        public ICommand ChangeDocumentCommand => new RelayCommand(async () =>
        {
            try
            {
                var document = await Db.Documents.FirstOrDefaultAsync(x => x.Id == Employee.Document.Id);
                document = Employee.Document;
                await Db.SaveChangesAsync();
                UpdateUser();
                MessageService.Message("Success", "Документ сохранен!");
                Messenger.Default.Send("UpdateEmployees");
            }
            catch
            {
                MessageService.Message("Error", "Заполните обязательные поля!");
            }
        });

        // Команда изменить пароль
        public ICommand ChangePasswordCommand => new RelayCommand(async () =>
        {

            if (NewPassword == ConfirmPassword)
            {
                if (await AuthService.UpdatePassword(Employee.User.Id, Password, NewPassword))
                {
                    UpdateUser();
                    MessageService.Message("Success", "Пароль сохранен!");
                    Messenger.Default.Send("UpdateEmployees");
                }
                else
                    MessageService.Message("Error", "Неверно введен старый пароль!");
            }
            else
                MessageService.Message("Error", "Пароли не совпадают");
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

        #region Методы

        /// <summary>
        /// Сообщение об изменении данных текущего пользователя
        /// </summary>
        void UpdateUser()
        {
            Messenger.Default.Send(new NotificationMessage<Employee>(this, Db.Employees
                                                        .Include(x => x.Role)
                                                        .Include(x => x.Document)
                                                        .Include(x => x.User)
                                                        .FirstOrDefault(x => x.Id == Employee.Id), "Update"));
            Password = String.Empty;
            NewPassword = String.Empty;
            ConfirmPassword = String.Empty;
        }

        #endregion

    }
}
