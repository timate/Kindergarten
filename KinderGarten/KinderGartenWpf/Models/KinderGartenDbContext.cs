using KinderGartenWpf.Models.Objects;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenWpf.Models
{
    public class KinderGartenDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LJJDRPA;Database=KinderGartenDB;Trusted_Connection=True;");
            //ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString
        }

        public KinderGartenDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        private PasswordHasher PasswordHasher = new PasswordHasher();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildrenGroup>()
            .HasKey(t => new { t.ChildrenId, t.GroupId });

            modelBuilder.Entity<ChildrenGroup>()
                .HasOne(sc => sc.Children)
                .WithMany(s => s.ChildrenGroups)
                .HasForeignKey(sc => sc.ChildrenId);

            modelBuilder.Entity<ChildrenGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.ChildrenGroups)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<ChildrenSubscription>()
            .HasKey(t => new { t.ChildrenId, t.SubscriptionId });

            modelBuilder.Entity<ChildrenSubscription>()
                .HasOne(sc => sc.Children)
                .WithMany(s => s.ChildrenSubscriptions)
                .HasForeignKey(sc => sc.ChildrenId);

            modelBuilder.Entity<ChildrenSubscription>()
                .HasOne(sc => sc.Subscription)
                .WithMany(c => c.ChildrenSubscriptions)
                .HasForeignKey(sc => sc.SubscriptionId);

            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Firstname = "admin", Lastname = "admin", Middlename = "admin" });
            modelBuilder.Entity<Document>().HasData(new Document { Id = 1 });
            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role
                {
                    Id = 1,
                    Name = "Заведующий"
                },
                new Role
                {
                    Id = 2,
                    Name = "Старший воспитатель"
                },
                new Role
                {
                    Id = 3,
                    Name = "Воспитатель"
                },
                new Role
                {
                    Id = 4,
                    Name = "Педагог"
                }
            });
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Login = "admin", PasswordHash = PasswordHasher.HashPassword("admin") });
            modelBuilder.Entity<Employee>().HasData(
                    new
                    {
                        Id = 1,
                        PersonId = 1,
                        DocumentsId = 1,
                        RoleId = 1,
                        UserId = 1,
                        HourSalary = 0m,
                        Salary = 0m
                    }
                );
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ChildrenGroup> ChildrenGroups { get; set; }
        public DbSet<ChildrenSubscription> ChildrenSubscriptions { get; set; }
        public DbSet<ScheduleTime> ScheduleTimes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<ParentRole> ParentRoles { get; set; }
        public DbSet<SubscriptionTemplate> Subscriptions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitStatus> VisitStatus { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
