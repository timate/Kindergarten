using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class User : ViewModelBase
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
