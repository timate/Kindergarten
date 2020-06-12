using ClosedXML.Report;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class FinanceReportViewModel : ViewModelBase
    {

        #region Свойства
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-30);
        public DateTime EndDate { get; set; } = DateTime.Now;
        public decimal Pribl { get; set; }
        public decimal Income { get; set; }
        public decimal Cunsumption { get; set; }

        public byte TabView { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<FileInfo> Files { get; set; }
        #endregion

        #region Конструктор

        public FinanceReportViewModel(KinderGartenDbContext db)
        {
            Db = db;
            Update();
            FilesUpdate();
            Messenger.Default.Send(new NotificationMessage<DateTime[]>(this, new DateTime[2] { StartDate, EndDate }, "Income"));
        }

        #endregion

        #region Команды

        public ICommand ChangeTabCommand => new RelayCommand<string>((numb) => IncomeUpdate(numb));

        public ICommand ViewCommand => new RelayCommand(() =>
        {
            Update();
        });

        public ICommand ExportCommand => new RelayCommand(async () =>
        {
            await Task.Run(async () =>
            {
                string outputFile = @"..\..\..\..\Reports\FinanceReports\Финансовый отчет - " + DateTime.Now.ToLongDateString() + ".xlsx";
                var template = new XLTemplate(@"..\..\..\..\ReportTemplates\FinanceReportTemplate.xlsx");
                string Period = $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
                var report = new Report
                {
                    Admin = await Db.Employees.Include(x => x.Person).FirstOrDefaultAsync(),
                    Period = Period,
                    Transactions = Transactions
                };
                template.AddVariable(report);
                template.Generate();

                template.SaveAs(outputFile);

                FilesUpdate();
            });
        });

        public ICommand OpenReportCommand => new RelayCommand<string>((path) =>
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true
            };
            process.Start();
        });

        #endregion

        #region Методы

        void Update()
        {
            Transactions = Db.Transactions.Include(x => x.Person)
                                          .Include(x => x.PaymentMethod)
                                          .Where(x => x.DateProcess.DayOfYear >= StartDate.DayOfYear && x.DateProcess.DayOfYear <= EndDate.DayOfYear).ToList();
            Income = Transactions.Where(x => x.Type).Sum(x => x.Amount);
            var Salary = Db.Employees.Sum(x => x.Salary);
            Cunsumption = Db.Transactions.Where(x => !x.Type).Sum(x => x.Amount);

            Pribl = Income - Cunsumption;
        }

        void FilesUpdate()
        {
            var Directory = new DirectoryInfo(@"..\..\..\..\Reports\FinanceReports\");
            Files = Directory.GetFiles().ToList();
        }

        void IncomeUpdate(string numb)
        {
            switch (Convert.ToByte(numb))
            {
                case 1:
                    Messenger.Default.Send(new NotificationMessage<DateTime[]>(this, new DateTime[2] { StartDate, EndDate }, "Income"));
                    break;
                case 2:
                    Messenger.Default.Send(new NotificationMessage<DateTime[]>(this, new DateTime[2] { StartDate, EndDate }, "Cunsumption"));
                    break;
            }
        }

        #endregion

        public class Report
        {
            public string Company = "МБДОУ «Балтасинский детский сад №3 общеразвивающего вида»";
            public string Street = "422250, Республика Татарстан, Балтасинский район, п.г.т.Балтаси, улица Ленина, дом 145";
            public string Email = "1272000003@edu.tatar.ru/baltasi.mdou3@yandex.ru";
            public string Phone = "+7(843)-682-54-70";
            public string Period { get; set; }
            public Employee Admin { get; set; }
            public List<Transaction> Transactions { get; set; }
        }

    }
}
