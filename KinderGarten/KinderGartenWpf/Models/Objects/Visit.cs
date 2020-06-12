using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Visit : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
        public byte Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Lesson Lesson { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public Children Children { get; set; }
    }
}
