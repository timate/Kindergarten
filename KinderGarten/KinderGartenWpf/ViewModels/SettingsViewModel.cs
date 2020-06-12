using GalaSoft.MvvmLight.Command;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Свойства
        public Page TabView { get; set; } = new RoomView();

        #endregion

        #region Команды

        public ICommand ChangeTabCommand => new RelayCommand<string>((numb) =>
        {
            switch (int.Parse(numb))
            {
                case 1:
                    TabView = new RoomView();
                    break;
                case 2:
                    TabView = new SubscriptionTemplates();
                    break;
                case 3:
                    TabView = new GroupsView();
                    break;
                default:
                    MessageBox.Show("Что-то пошло не так!");
                    break;
            }
        });

        #endregion

        #region Конструктор

        public SettingsViewModel()
        {
        }

        #endregion
    }
}
