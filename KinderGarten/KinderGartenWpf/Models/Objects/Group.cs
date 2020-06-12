using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class Group : ViewModelBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public List<ChildrenGroup> ChildrenGroups { get; set; }

        public Group()
        {
            ChildrenGroups = new List<ChildrenGroup>();
        }
    }
}
