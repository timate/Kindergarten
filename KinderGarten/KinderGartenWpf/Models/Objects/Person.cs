using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Person : ViewModelBase
    {
        [Key]
        public int Id { get; set; }

        public byte[] Image { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ошибка")]
        public string Lastname { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Middlename { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
