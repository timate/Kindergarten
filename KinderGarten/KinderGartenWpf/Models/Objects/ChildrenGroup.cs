using GalaSoft.MvvmLight;

namespace KinderGartenWpf.Models.Objects
{
    public class ChildrenGroup : ViewModelBase
    {
        public int ChildrenId { get; set; }
        public Children Children { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
