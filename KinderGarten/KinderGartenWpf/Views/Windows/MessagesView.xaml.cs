using System.Windows;

namespace KinderGartenWpf.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MessagesView.xaml
    /// </summary>
    public partial class MessagesView : Window
    {
        public MessagesView(int messages)
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;


            this.Top = screenHeight - this.Height - (messages * 100);
            this.Left = screenWidth - this.Width;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
