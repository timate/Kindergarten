using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGartenWpf.Models.Objects
{
    public class ChildrenSubscription : ViewModelBase
    {
        public int ChildrenId { get; set; }
        public Children Children { get; set; }
        public int SubscriptionId { get; set; }
        public SubscriptionTemplate Subscription { get; set; }
    }
}
