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
    public class VisitsReportViewModel : ViewModelBase
    {
        #region Свойства

        public List<Group> Groups { get; set; }
        public List<VisitsReport> Visits { get; set; }

        public DateTime Start { get; set; } = DateTime.Now.AddMonths(-1);
        public DateTime End { get; set; } = DateTime.Now;
        public Group SelectedGroup { get; set; }

        public List<FileInfo> Files { get; set; }

        #endregion

        #region Конструктор
        public VisitsReportViewModel(KinderGartenDbContext db)
        {
            Db = db;

            Groups = Db.Groups.ToList();
            SelectedGroup = Groups?.FirstOrDefault();

            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateGroups")
                    Groups = Db.Groups.ToList();
            });

            Update();
            FilesUpdate();
        }
        #endregion

        #region Команды

        public ICommand ViewCommand => new RelayCommand(() =>
        {
            Update();
        });

        public ICommand ExportCommand => new RelayCommand(async () =>
        {

            await Task.Run(async () =>
            {
                string outputFile = @"..\..\..\..\Reports\VisitReports\Отчет посещении - " + DateTime.Now.ToLongDateString() + ".xlsx";
                var template = new XLTemplate(@"..\..\..\..\ReportTemplates\VisitsReportTemplate.xlsx");
                string Period = $"{Start.ToShortDateString()} - {End.ToShortDateString()}";
                var report = new Report
                {
                    Admin = await Db.Employees.Include(x => x.Person).FirstOrDefaultAsync(),
                    Period = Period,
                    Group = SelectedGroup.Name,
                    Visits = Visits
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

        void FilesUpdate()
        {
            var Directory = new DirectoryInfo(@"..\..\..\..\Reports\VisitReports\");
            Files = Directory.GetFiles().ToList();
        }

        void Update()
        {
            Groups = Db.Groups.ToList();
            Visits = Db.Visits.Where(x => x.Date >= Start && x.Date <= End).GroupBy(x => new { x.Children.Person.Lastname, x.Children.Person.Firstname, x.Children.Person.Middlename, x.VisitStatus.Name })
                .Select(g => new VisitsReport { Lastname = g.Key.Lastname, Firstname = g.Key.Firstname, Middlename = g.Key.Middlename, Status = g.Key.Name, Count = g.Count() }).ToList();
        }

        #endregion

        public class VisitsReport
        {
            public string Lastname { get; set; }
            public string Firstname { get; set; }
            public string Middlename { get; set; }
            public string Status { get; set; }
            public int Count { get; set; }

        }

        public class Report
        {
            public string Company = "МБДОУ «Балтасинский детский сад №3 общеразвивающего вида»";
            public string Street = "422250, Республика Татарстан, Балтасинский район, п.г.т.Балтаси, улица Ленина, дом 145";
            public string Email = "1272000003@edu.tatar.ru/baltasi.mdou3@yandex.ru";
            public string Phone = "+7(843)-682-54-70";
            public string Period { get; set; }
            public string Group { get; set; }
            public Employee Admin { get; set; }
            public List<VisitsReport> Visits { get; set; }
        }
    }
}
