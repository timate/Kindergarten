using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Base
{
    public class DialogViewModel : ViewModelBase
    {

        #region Команды

        //Команда закрыть окно
        public ICommand CloseCommand =>
            new RelayCommand<Window>((obj) => { obj.Close(); });

        // Команда перетаскивания окна
        public ICommand WindowDragCommand =>
            new RelayCommand<Window>((obj) =>
            {
                try { obj.DragMove(); }
                catch { }
            });

        #endregion

    }
}
