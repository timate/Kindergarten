using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Children
    {
        [Key]
        public int Id { get; set; }
        public List<Parent> Parents { get; set; }

        public List<ChildrenSubscription> ChildrenSubscriptions { get; set; }

        public List<ChildrenGroup> ChildrenGroups { get; set; }
        public Person Person { get; set; }
    }
}
