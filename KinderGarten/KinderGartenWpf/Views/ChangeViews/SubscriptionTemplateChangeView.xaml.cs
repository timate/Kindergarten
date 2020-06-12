using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.Views.ChangeViews
{
    /// <summary>
    /// Логика взаимодействия для SubscriptionTemplateChangeView.xaml
    /// </summary>
    public partial class SubscriptionTemplateChangeView : Window
    {
        public SubscriptionTemplateChangeView()
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
