using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels.Dialog
{
    public class ChildrenChangeViewModel : DialogViewModel
    {
        #region Свойства
        public Visibility AddVisibility { get; set; }
        public Visibility ChangeVisibility { get; set; }
        public Children Children { get; set; }
        public List<Group> Groups { get; set; }
        public string Title { get; set; }

        #endregion

        #region Конструктор

        public ChildrenChangeViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;

            Groups = Db.Groups.ToList();

            Messenger.Default.Register<string>(this, message =>
            {
                if (message == "UpdateGroups")
                    Groups = Db.Groups.ToList();
            });

            Messenger.Default.Register<NotificationMessage<Children>>(this, message =>
            {
                if (message.Notification == "Add")
                {
                    Title = "Новый ребенок";
                    Children = new Children
                    {
                        Person = new Person(),
                    };
                    AddVisibility = Visibility.Visible;
                    ChangeVisibility = Visibility.Collapsed;
                }
                else if (message.Notification == "Change")
                {
                    Children = message.Content;
                    Title = "Редактирование ребенка";
                    AddVisibility = Visibility.Collapsed;
                    ChangeVisibility = Visibility.Visible;
                }
            });

        }
        #endregion

        #region Команды
        // Команда добавить
        public ICommand AddCommand => new RelayCommand<Window>((obj) =>
        {
            Db.Childrens.Add(Children);
            Db.SaveChanges();
            obj.DialogResult = true;
            Children = null;
            obj.Close();
            MessageService.Message("Success", "Ребенок добавлен!");
        });
        // Команда изменить
        public ICommand ChangeCommand => new RelayCommand<Window>((obj) =>
        {
            Db.SaveChanges();
            obj.DialogResult = true;
            Children = null;
            obj.Close();
            MessageService.Message("Success", "Данные успешно изменены!");
        });
        // Команда удалить
        public ICommand RemoveCommand => new RelayCommand<Window>((obj) =>
        {
            Db.Childrens.Remove(Children);
            Db.SaveChanges();
            obj.DialogResult = true;
            Children = null;
            obj.Close();
            MessageService.Message("Success", "Ребенок удален!");
        });

        public ICommand PhotoChangeCommand => new RelayCommand(() =>
        {
            OpenFileDialog dlg = new OpenFileDialog();
            ImageConverter imageConverter = new ImageConverter();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
                Children.Person.Image = (byte[])imageConverter.ConvertTo(System.Drawing.Image.FromFile(dlg.FileName), typeof(byte[]));
        });

        #endregion
    }
}
