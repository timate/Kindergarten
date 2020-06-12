using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.ViewModels.Dialog;
using KinderGartenWpf.Views.ChangeViews;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KinderGartenWpf.ViewModels
{
    public class RoomViewModel : ViewModelBase
    {
        #region Свойства
        public ScheduleTime Times { get; set; }
        public Room SelectedRoom { get; set; }
        public ParentRole SelectedParent { get; set; }
        public VisitStatus SelectedVisit { get; set; }
        public PaymentMethod SelectedMethod { get; set; }
        public Visibility BtnVisibility { get => SelectedRoom is null ? Visibility.Collapsed : Visibility.Visible; }
        public Visibility Btn1Visibility { get => SelectedMethod is null ? Visibility.Collapsed : Visibility.Visible; }
        public Visibility Btn2Visibility { get => SelectedParent is null ? Visibility.Collapsed : Visibility.Visible; }
        public Visibility Btn3Visibility { get => SelectedMethod is null ? Visibility.Collapsed : Visibility.Visible; }
        public Visibility Btn4Visibility { get => SelectedVisit is null ? Visibility.Collapsed : Visibility.Visible; }
        public List<Room> Rooms { get; set; }
        public List<Role> Roles { get; set; }
        public List<ParentRole> ParentRoles { get; set; }
        public List<VisitStatus> VisitStatuses { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }

        #endregion

        #region Команды

        public ICommand SaveCommand => new RelayCommand(async () =>
        {
            var times = await Db.ScheduleTimes.FirstOrDefaultAsync();
            if (times is null)
                await Db.ScheduleTimes.AddAsync(Times);
            else
                times = Times;
            await Db.SaveChangesAsync();
            MessageService.Message("Success", "Настройки времени сохранены!");
            Messenger.Default.Send("ScheduleTimesUpdate");
        });

        public ICommand RoomRemoveCommand => new RelayCommand(async () =>
        {
            Db.Rooms.Remove(SelectedRoom);
            await Db.SaveChangesAsync();
            Update();
            Messenger.Default.Send("UpdateRooms");
        });

        public ICommand RoomChangeCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, "Редктирование помещения", "Название"));
            dialog.ShowDialog();
            if(dialog.DialogResult == true)
            Messenger.Default.Send("UpdateRooms");
        });

        public ICommand RoomAddCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, dialog.DataContext, "Новое помещение", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdateRooms");
        });

        public ICommand ParentRoleRemoveCommand => new RelayCommand(async () =>
        {
            Db.ParentRoles.Remove(SelectedParent);
            await Db.SaveChangesAsync();
            Update();
            Messenger.Default.Send("UpdateParentRoles");
        });

        public ICommand ParentRoleChangeCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, "Редктирование родительского роля", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdateParentRoles");
        });

        public ICommand ParentRoleAddCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, dialog.DataContext, "Новая родительская роль", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdateParentRoles");
        });

        public ICommand MethodRemoveCommand => new RelayCommand(async () =>
        {
            Db.PaymentMethods.Remove(SelectedMethod);
            await Db.SaveChangesAsync();
            Update();
            Messenger.Default.Send("UpdatePaymentMethods");
        });

        public ICommand MethodChangeCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, "Редктирование способа платежа", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdatePaymentMethods");
        });

        public ICommand MethodAddCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, dialog.DataContext, "Новый способ платежа", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdatePaymentMethods");
        });

        public ICommand VisitRemoveCommand => new RelayCommand(async () =>
        {
            Db.VisitStatus.Remove(SelectedVisit);
            await Db.SaveChangesAsync();
            Update();
            Messenger.Default.Send("UpdateVisitStatuses");
        });

        public ICommand VisitChangeCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, "Редктирование статуса посещения", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdateVisitStatuses");
        });

        public ICommand VisitAddCommand => new RelayCommand(() =>
        {
            var dialog = new DialogView();
            Messenger.Default.Send(new NotificationMessage<string>(this, dialog.DataContext, "Новый статус посещения", "Название"));
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
                Messenger.Default.Send("UpdateVisitStatuses");
        });





        #endregion

        #region Конструктор
        public RoomViewModel(KinderGartenDbContext db, MessageService messageService)
        {
            Db = db;
            MessageService = messageService;
            Messenger.Default.Register<NotificationMessage<string>>(this, async message =>
            {
                if (message.Sender is SingleDialogViewModel)
                {
                    if (message.Content == "Редактирование помещения")
                    {
                        var room = await Db.Rooms.FirstOrDefaultAsync(x => x == SelectedRoom);
                        room.Name = message.Notification;

                        MessageService.Message("Success", "Помещение сохранено!");
                    }
                    if (message.Content == "Новое помещение")
                    {
                        await Db.Rooms.AddAsync(new Room { Name = message.Notification });
                        await Db.SaveChangesAsync();
                        MessageService.Message("Success", "Помещение добавлено!");
                    }
                    if (message.Content == "Редактирование родительского роля")
                    {
                        var room = await Db.ParentRoles.FirstOrDefaultAsync(x => x == SelectedParent);
                        room.Name = message.Notification;

                        MessageService.Message("Success", "Роль сохранена!");
                    }
                    if (message.Content == "Новая родительская роль")
                    {
                        await Db.ParentRoles.AddAsync(new ParentRole { Name = message.Notification });
                        await Db.SaveChangesAsync();
                        MessageService.Message("Success", "Роль добавлена!");
                    }
                    if (message.Content == "Редактирование способа платежа")
                    {
                        var room = await Db.PaymentMethods.FirstOrDefaultAsync(x => x == SelectedMethod);
                        room.Name = message.Notification;

                        MessageService.Message("Success", "Способ платежа сохранен!");
                    }
                    if (message.Content == "Новый способ платежа")
                    {
                        await Db.PaymentMethods.AddAsync(new PaymentMethod { Name = message.Notification });
                        await Db.SaveChangesAsync();
                        MessageService.Message("Success", "Способ платежа добавлен!");
                    }
                    if (message.Content == "Редактирование статуса посещения")
                    {
                        var room = await Db.VisitStatus.FirstOrDefaultAsync(x => x == SelectedVisit);
                        room.Name = message.Notification;

                        MessageService.Message("Success", "Способ платежа сохранен!");
                    }
                    if (message.Content == "Новый статус посещения")
                    {
                        await Db.VisitStatus.AddAsync(new VisitStatus { Name = message.Notification });
                        await Db.SaveChangesAsync();
                        MessageService.Message("Success", "Способ платежа добавлен!");
                    }
                    await Db.SaveChangesAsync();
                    Update();
                }
            });
            Update();
        }
        #endregion

        #region Методы

        void Update()
        {
            Times = Db.ScheduleTimes.FirstOrDefault();
            if (Times is null)
                Times = new ScheduleTime();
            Rooms = Db.Rooms.ToList();
            Roles = Db.Roles.ToList();
            ParentRoles = Db.ParentRoles.ToList();
            VisitStatuses = Db.VisitStatus.ToList();
            PaymentMethods = Db.PaymentMethods.ToList();
        }

        #endregion
    }
}
