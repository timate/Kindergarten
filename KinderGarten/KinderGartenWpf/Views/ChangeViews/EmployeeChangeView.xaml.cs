using System.Windows.Controls;
using System.Windows.Input;

namespace KinderGartenWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class EmployeeChangeView : Page
    {
        public EmployeeChangeView()
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
