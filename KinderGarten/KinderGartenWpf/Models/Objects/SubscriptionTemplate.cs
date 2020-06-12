using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class SubscriptionTemplate : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } // Название
        [MaxLength(8)]
        public decimal Amount { get; set; } // Сумма
        public Employee Employee { get; set; } // Педагог
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int HoursCount { get; set; }
        public List<ChildrenSubscription> ChildrenSubscriptions { get; set; }

        public SubscriptionTemplate()
        {
            ChildrenSubscriptions = new List<ChildrenSubscription>();
        }
    }
}
