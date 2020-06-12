using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddView.xaml
    /// </summary>
    public partial class EmployeeAddView : Window
    {
        public EmployeeAddView()
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
