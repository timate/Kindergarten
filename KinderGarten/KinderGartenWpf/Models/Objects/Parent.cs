using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Parent : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
        public Person Person { get; set; }
        public ParentRole ParentRole { get; set; }

        public Children Children { get; set; }
    }
}
