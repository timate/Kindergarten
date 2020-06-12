using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(8)]
        public decimal Salary { get; set; }
        public decimal HourSalary { get; set; }
        public Person Person { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public Group Group { get; set; }
        public Document Document { get; set; }
        public List<SubscriptionTemplate> Subscriptions { get; set; }
    }
}
