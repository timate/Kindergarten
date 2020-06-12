using GalaSoft.MvvmLight.Command;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Dialog
{
    public class SalaryChangeViewModel : DialogViewModel
    {
        #region Свойства

        public List<PaymentMethod> PaymentMethods { get; set; }
        public PaymentMethod SelectedPaymentMethod { get; set; }
        public List<Employee> Employees { get; set; }
        [AlsoNotifyFor("Amount")]
        public Employee SelectedEmployee { get; set; }
        private int Visits
        {
            get
            {
                if (SelectedEmployee != null)
                {
                    return Db.Visits.Where(x => x.Lesson.Employee == SelectedEmployee &&
                                          x.Date.Month == DateTime.Now.Month &&
                                          x.Date.Year == DateTime.Now.Year && x.Lesson.Tariff == null).Count();
                }
                return 0;
            }
        }
        public string Title { get; set; } = "Выплата заработной платы";
        [AlsoNotifyFor("Amount")]
        public decimal Premial { get; set; }
        public decimal Amount
        {
            get
            {
                if (SelectedEmployee != null)
                {
                    var Bid = SelectedEmployee.Salary;
                    switch (Convert.ToByte(Type))
                    {
                        case 1:
                            Bid += SelectedEmployee.HourSalary * Visits;
                            break;
                        case 2:
                            Bid += (SelectedEmployee.HourSalary * 1.5m) * Visits;
                            break;
                        case 3:
                            Bid += (SelectedEmployee.HourSalary * 2) * Visits;
                            break;
                    }
                    var visits = Db.Visits.Include(x => x.Lesson).ThenInclude(x => x.Tariff).Where(x => x.Lesson.Employee == SelectedEmployee &&
                                              x.Date.Month == DateTime.Now.Month &&
                                              x.Date.Year == DateTime.Now.Year && x.Lesson.Tariff != null).ToList();
                    if (visits != null)
                        foreach (Visit i in visits)
                        {
                            Bid += i.Lesson.Tariff.Amount - (i.Lesson.Tariff.Amount * 0.05m);
                        }
                    return Bid + Premial;
                };
                return 0;
            }
        }
        [AlsoNotifyFor("Amount")]
        public byte Type { get; set; }

        #endregion

        #region Конструктор

        public SalaryChangeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Employees = Db.Employees.Include(x => x.Person).ToList();
            PaymentMethods = Db.PaymentMethods.ToList();
        }
        #endregion

        #region Команды

        public ICommand BidChangeCommand => new RelayCommand<string>((obj) => Type = Convert.ToByte(obj));

        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>(async (obj) =>
        {
            try
            {
                if (await Db.Transactions.FirstOrDefaultAsync(x => x.Person == SelectedEmployee.Person && x.DateProcess.Month == DateTime.Now.Month && x.Type == false) is null)
                {
                    await Db.Transactions.AddAsync(new Transaction
                    {
                        Amount = Amount,
                        Comment = "Зарплата",
                        DateProcess = DateTime.Now,
                        PaymentMethod = SelectedPaymentMethod,
                        Type = false,
                        Person = SelectedEmployee.Person
                    });
                    await Db.SaveChangesAsync();
                    MessageService.Message("Success", $"Заработная плата {SelectedEmployee.Person.Lastname} {SelectedEmployee.Person.Firstname[0]}. {SelectedEmployee.Person.Firstname[1]}. в сумме {Amount} руб. выплачена!");
                    obj.DialogResult = true;
                    obj.Close();
                }
                else
                {
                    MessageService.Message("Error", "Ошибка при выплате заработной платы!");
                }
            }
            catch
            {
                MessageService.Message("Error", "Ошибка при выплате заработной платы!");
            }

        });

        #endregion
    }
}
