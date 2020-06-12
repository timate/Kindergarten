using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.Views.ChangeViews
{
    /// <summary>
    /// Логика взаимодействия для ChildrenAdd.xaml
    /// </summary>
    public partial class ChildrenChangeView : Window
    {

        public ChildrenChangeView()
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
