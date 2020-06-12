using GalaSoft.MvvmLight.Messaging;

namespace KinderGartenWpf.Services
{
    public class NavigationService
    {
        /// <summary>
        /// Переход на другую страницу
        /// </summary>
        /// <param name="Page"></param>
        public void Navigate(string Page)
        {
            Messenger.Default.Send(new NotificationMessage<string>(Page, "Navigate"));
        }

        /// <summary>
        /// Назад
        /// </summary>
        public void Back()
        {
            Messenger.Default.Send(new NotificationMessage<string>(null, "Back"));
        }

    }
}
