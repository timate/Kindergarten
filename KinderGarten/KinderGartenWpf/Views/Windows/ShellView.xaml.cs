using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace KinderGartenWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage<string>>(this, message =>
            {
                if (message.Notification == "Back")
                    MainFrame.GoBack();
                else
                {
                    switch (message.Content)
                    {
                        case "Analytics":
                            MainFrame.Content = new AnalyticsView();
                            break;
                        case "Cabinet":
                            MainFrame.Content = new CabinetView();
                            break;
                        case "Childrens":
                            MainFrame.Content = new ChildrensView();
                            break;
                        case "Children":
                            MainFrame.Content = new ChildrenView();
                            break;
                        case "Employees":
                            MainFrame.Content = new EmployeesView();
                            break;
                        case "Settings":
                            MainFrame.Content = new SettingsView();
                            break;
                        case "Visits":
                            MainFrame.Content = new VisitsView();
                            break;
                        case "Main":
                            MainFrame.Content = new MainView();
                            break;
                        case "Schedule":
                            MainFrame.Content = new ScheduleView();
                            break;
                        case "Finances":
                            MainFrame.Content = new FinancesView();
                            break;
                    }
                }
                Messenger.Default.Send(MainFrame.CanGoBack);
            });
        }
    }
}