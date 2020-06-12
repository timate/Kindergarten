using KinderGartenWpf.ViewModels.Base;

namespace KinderGartenWpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Свойства

        /*public Employee Employee { get => Db?.Employees.Include(x=>x.Group).First(x=>x.Id == App.UserId); }
        public bool FinancesVisibility { get => App.RoleId == 1; }
        public bool BirthDayVisibility { get => Childrens?.Count != 0; }
        public bool LessonsVisibility { get => Lessons?.Count != 0; }
        public bool GroupLessonsVisibility { get; set; }
        public List<Children> Childrens { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Lesson> GroupLessons { get; set; }*/

        #endregion

        #region Конструктор

        /*public MainViewModel(KinderGartenDbContext db)
        {
            Db = db;

            if(Employee != null && Employee.Group != null)
            {
                Childrens = Db.Childrens.Where(x => x.ChildrenGroups.FirstOrDefault(x => x.Group == Employee.Group) != null).ToList();
            }
        }*/

        #endregion
    }
}
