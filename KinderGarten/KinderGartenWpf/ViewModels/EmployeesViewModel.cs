using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        #region Свойства
        public bool GridEmptyVisibility { get => Employees.Count() == 0; }
        public bool RemoveBtnVisibility { get => SelectedItem != null && App.RoleId == 1; }
        public bool AddBtnVisibility { get => App.RoleId == 1; }
        public List<Employee> Employees { get; set; }
        public string Search { get; set; }

        public Employee SelectedItem { get; set; }

        #endregion

        #region Конструктор

        public EmployeesViewModel(KinderGartenDbContext db, NavigationService navService, MessageService messageService)
        {
            Db = db;
            NavService = navService;
            MessageService = messageService;
            Update();
            MessageService.Message("Info", "Чтобы посмотреть подробную информацию, дважды щелкните по педагогу");

            Messenger.Default.Register<NotificationMessage<int>>(this, message =>
            {
                if (message.Sender is ShellViewModel)
                {
                    UserRole = message.Content;
                }
            });
        }

        #endregion

        #region Команды
        //Команда поиска
        public ICommand SearchCommand => new RelayCommand(() => Update());

        //Команда добавить
        public ICommand AddCommand => new RelayCommand(() =>
        {

            var Dialog = new EmployeeAddView();
            Messenger.Default.Send(new NotificationMessage<Employee>(this, null, "Add"));
            Dialog.ShowDialog();
            if (Dialog.DialogResult == true)
                Update();
        });

        //Команда для просмотра подробной информации
        public ICommand GridDoubleCommand => new RelayCommand(() =>
        {
            NavService.Navigate("Cabinet");
            Messenger.Default.Send(new NotificationMessage<Employee>(this, SelectedItem, "Detail"));
        });

        // Команда изменить
        public ICommand RemoveCommand => new RelayCommand(async () =>
        {
            Db.Employees.Remove(SelectedItem);
            await Db.SaveChangesAsync();
            MessageService.Message("Success", "Сотрудник удален!");
            Update();
            Messenger.Default.Send("UpdateEmployees");
        });

        #endregion

        #region Методы

        /// <summary>
        /// Обновляет таблицу педагогов
        /// </summary>
        void Update()
        {
            if (string.IsNullOrWhiteSpace(Search))
                Employees = Db.Employees.Include(x => x.Role).Include(x => x.Person).Include(x => x.Document).Include(x => x.User).ToList();
            else
            {
                Employees = Db.Employees.Include(x => x.Role).Include(x => x.Person).Include(x => x.Document).Include(x => x.User)
                              .Where(x => (x.Person.Firstname + x.Person.Lastname + x.Person.Middlename + x.Person.Phone).Contains(Search)).ToList();
            }
        }

        #endregion
    }
}
