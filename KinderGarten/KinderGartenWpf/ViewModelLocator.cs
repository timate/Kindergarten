using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using KinderGartenWpf.Models;
using KinderGartenWpf.Services;
using KinderGartenWpf.ViewModels;
using KinderGartenWpf.ViewModels.Base;
using KinderGartenWpf.ViewModels.Dialog;

namespace KinderGartenWpf
{

    public class ViewModelLocator
    {

        #region Свойства

        #region ViewModels

        public ShellViewModel ShellVM => SimpleIoc.Default.GetInstance<ShellViewModel>();
        public SignViewModel SignVM => SimpleIoc.Default.GetInstance<SignViewModel>();
        public CabinetViewModel CabinetVM => SimpleIoc.Default.GetInstance<CabinetViewModel>();
        public DialogViewModel DialogVM => SimpleIoc.Default.GetInstance<DialogViewModel>();
        public EmployeesViewModel EmployeesVM => SimpleIoc.Default.GetInstance<EmployeesViewModel>();
        public ScheduleViewModel RaspVM => SimpleIoc.Default.GetInstance<ScheduleViewModel>();
        public SettingsViewModel SettingsVM => SimpleIoc.Default.GetInstance<SettingsViewModel>();
        public FinancesViewModel FinancesVM => SimpleIoc.Default.GetInstance<FinancesViewModel>();
        public ChildrensViewModel ChildrensVM => SimpleIoc.Default.GetInstance<ChildrensViewModel>();
        public ChildrenViewModel ChildrenVM => SimpleIoc.Default.GetInstance<ChildrenViewModel>();
        public VisitsViewModel VisitsVM => SimpleIoc.Default.GetInstance<VisitsViewModel>();
        public RoomViewModel RoomVM => SimpleIoc.Default.GetInstance<RoomViewModel>();
        public SubscriptionViewModel SubscriptionVM => SimpleIoc.Default.GetInstance<SubscriptionViewModel>();
        public SubscriptionTemplatesViewModel TemplatesVM => SimpleIoc.Default.GetInstance<SubscriptionTemplatesViewModel>();
        public GroupsViewModel GroupsVM => SimpleIoc.Default.GetInstance<GroupsViewModel>();
        public IncomeViewModel IncomeVM => SimpleIoc.Default.GetInstance<IncomeViewModel>();
        public ParentsViewModel ParentsVM => SimpleIoc.Default.GetInstance<ParentsViewModel>();
        public EmployeeChangeViewModel EmployeeChangeVM => SimpleIoc.Default.GetInstance<EmployeeChangeViewModel>();
        public AnalyticsViewModel AnlayticsVM => SimpleIoc.Default.GetInstance<AnalyticsViewModel>();
        public FinanceReportViewModel FinanceReportVm => SimpleIoc.Default.GetInstance<FinanceReportViewModel>();
        public SuccessLessonsViewModel SuccessLessonsVM => SimpleIoc.Default.GetInstance<SuccessLessonsViewModel>();
        public VisitsReportViewModel VisitsReportVM => SimpleIoc.Default.GetInstance<VisitsReportViewModel>();
        public MainViewModel MainVM => SimpleIoc.Default.GetInstance<MainViewModel>();

        #endregion

        #region ViewModels для диалоговых окон

        public SingleDialogViewModel SingleDialogVM => SimpleIoc.Default.GetInstance<SingleDialogViewModel>();
        public SubscriptionChangeViewModel SubscriptionChangeVM => SimpleIoc.Default.GetInstance<SubscriptionChangeViewModel>();
        public ChildrenChangeViewModel ChilrderChangeVM => SimpleIoc.Default.GetInstance<ChildrenChangeViewModel>();
        public EmployeeAddViewModel EmployeeAddVM => SimpleIoc.Default.GetInstance<EmployeeAddViewModel>();
        public SheduleChangeViewModel SheduleChangeVM => SimpleIoc.Default.GetInstance<SheduleChangeViewModel>();
        public ParentChangeViewModel ParentChangeVM => SimpleIoc.Default.GetInstance<ParentChangeViewModel>();
        public TemplateChangeViewModel TemplateChangeVM => SimpleIoc.Default.GetInstance<TemplateChangeViewModel>();
        public SalaryChangeViewModel SalaryChangeVM => SimpleIoc.Default.GetInstance<SalaryChangeViewModel>();

        #endregion

        #endregion

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Регистрация сервисов

            SimpleIoc.Default.Register<NavigationService>();
            SimpleIoc.Default.Register<AuthenticationService>();
            SimpleIoc.Default.Register<MessageService>();
            SimpleIoc.Default.Register<KinderGartenDbContext>();

            #endregion

            #region Регистрация ViewModels

            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<SignViewModel>();
            SimpleIoc.Default.Register<ViewModelBase>();
            SimpleIoc.Default.Register<ScheduleViewModel>();
            SimpleIoc.Default.Register<CabinetViewModel>();
            SimpleIoc.Default.Register<EmployeesViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<SubscriptionChangeViewModel>();
            SimpleIoc.Default.Register<SubscriptionTemplatesViewModel>();
            SimpleIoc.Default.Register<SubscriptionViewModel>();
            SimpleIoc.Default.Register<FinancesViewModel>();
            SimpleIoc.Default.Register<ChildrensViewModel>();
            SimpleIoc.Default.Register<ChildrenViewModel>();
            SimpleIoc.Default.Register<VisitsViewModel>();
            SimpleIoc.Default.Register<RoomViewModel>();
            SimpleIoc.Default.Register<GroupsViewModel>();
            SimpleIoc.Default.Register<IncomeViewModel>();
            SimpleIoc.Default.Register<TemplateChangeViewModel>();
            SimpleIoc.Default.Register<ParentsViewModel>();
            SimpleIoc.Default.Register<AnalyticsViewModel>();
            SimpleIoc.Default.Register<FinanceReportViewModel>();
            SimpleIoc.Default.Register<SuccessLessonsViewModel>();
            SimpleIoc.Default.Register<VisitsReportViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();

            #endregion

            #region Регистрация ViewModels для диалоговых окон

            SimpleIoc.Default.Register<SingleDialogViewModel>();
            SimpleIoc.Default.Register<ChildrenChangeViewModel>();
            SimpleIoc.Default.Register<EmployeeAddViewModel>();
            SimpleIoc.Default.Register<SheduleChangeViewModel>();
            SimpleIoc.Default.Register<ParentChangeViewModel>();
            SimpleIoc.Default.Register<EmployeeChangeViewModel>();
            SimpleIoc.Default.Register<SalaryChangeViewModel>();

            #endregion

        }

    }
}
