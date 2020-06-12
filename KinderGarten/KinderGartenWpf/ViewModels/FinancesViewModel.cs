using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class FinancesViewModel : ViewModelBase
    {
        #region Свойства
        public Page TabView { get; set; } = new IncomeView();

        #endregion

        #region Команды

        public ICommand ChangeTabCommand => new RelayCommand<string>((numb) =>
        {
            switch (int.Parse(numb))
            {
                case 1:
                    TabView = new IncomeView();
                    Messenger.Default.Send(new NotificationMessage(this, "Income"));
                    break;
                case 2:
                    TabView = new IncomeView();
                    Messenger.Default.Send(new NotificationMessage(this, "Cunsumption"));
                    break;
            }
        });

        #endregion

        #region Конструктор

        public FinancesViewModel()
        {
        }

        #endregion
    }
}
