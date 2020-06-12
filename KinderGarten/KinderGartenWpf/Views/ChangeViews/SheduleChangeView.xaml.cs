using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.Views.Dialog
{
    /// <summary>
    /// Логика взаимодействия для SheduleChangeView.xaml
    /// </summary>
    public partial class SheduleChangeView : Window
    {
        public SheduleChangeView()
        {
            InitializeComponent();
        }

        void OnlyLetters(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        void OnlyDigits(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
