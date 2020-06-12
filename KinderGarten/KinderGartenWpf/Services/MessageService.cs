using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Views.Windows;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KinderGartenWpf.Services
{
    public class MessageService
    {
        public int Messages { get; set; }

        /// <summary>
        /// Новое сообщение
        /// </summary>
        /// <param name="type">Типы: Error, Info, Success</param>
        /// <param name="message">Сообщение</param>
        public void Message(string type, string message)
        {

            Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                var MessageWindow = new MessagesView(Messages);
                switch (type)
                {
                    case "Error":
                        MessageWindow.Message.Background = Brushes.IndianRed;
                        MessageWindow.Content.Foreground = Brushes.GhostWhite;
                        break;
                    case "Info":
                        MessageWindow.Message.Background = Brushes.RoyalBlue;
                        MessageWindow.Content.Foreground = Brushes.White;
                        break;
                    case "Success":
                        MessageWindow.Message.Background = Brushes.LimeGreen;
                        MessageWindow.Content.Foreground = Brushes.GhostWhite;
                        break;
                }
                MessageWindow.Content.Text = message;
                MessageWindow.Show();
                Messages++;
                MessageWindow.Closing += MessageWindow_Closed;
                await Task.Delay(5000);
                MessageWindow.Close();
            });
            Messenger.Default.Register<string>(this, a =>
            {
                Messages = Messages == 0 ? 0 : Messages--;
            });
        }

        private void MessageWindow_Closed(object sender, System.EventArgs e)
        {
            Messages--;
        }
    }
}
