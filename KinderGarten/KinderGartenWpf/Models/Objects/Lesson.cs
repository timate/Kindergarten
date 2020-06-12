using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Lesson : ViewModelBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public int DayOfWeek { get; set; }

        [MaxLength(1)]
        public byte LessonNumber { get; set; }
        public Group Group { get; set; }
        public Room Room { get; set; }
        public Employee Employee { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public SubscriptionTemplate Tariff { get; set; }
    }
}
