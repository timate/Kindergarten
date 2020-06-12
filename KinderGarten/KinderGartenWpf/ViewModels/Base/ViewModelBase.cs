using KinderGartenWpf.Models;
using KinderGartenWpf.Services;

namespace KinderGartenWpf.ViewModels.Base
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        public NavigationService NavService;
        public KinderGartenDbContext Db;
        public MessageService MessageService;
        public int UserRole { get; set; }
    }
}
