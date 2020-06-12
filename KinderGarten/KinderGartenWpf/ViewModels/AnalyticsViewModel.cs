using GalaSoft.MvvmLight.Command;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class AnalyticsViewModel : ViewModelBase
    {

        #region Свойства

        public Page TabView { get; set; } = new FinanceReportView();

        #endregion

        #region Конструктор

        public AnalyticsViewModel()
        {

        }

        #endregion

        #region Команды

        public ICommand ChangeTabCommand => new RelayCommand<string>((numb) =>
        {
            switch (int.Parse(numb))
            {
                case 1:
                    TabView = new FinanceReportView();
                    break;
                case 3:
                    TabView = new VisitsReportView();
                    break;
            }
        });

        #endregion

    }
}
