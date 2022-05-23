using HR.EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.EmployeeManagement.Persistance
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagementDbContext).Assembly);

            //teams
            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 2,
                TeamName = "User interface team",
                Description = "Team for designing UI"
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 1,
                TeamName = "Database team",
                Description = "Team for database"
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 3,
                TeamName = "Infrastructure team",
                Description = "Team for architecture and infrastructure"
            });

            // employees

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 100,
                Name = "John",
                LastName = "Doe",
                Address = "Street Red 1",
                City = "Atlanta",
                Email = "jac@cd.com",
                Phone = "12312",
                TeamId = 1
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 101,
                Name = "Don",
                LastName = "Jonson",
                Address = "Redmong street 123",
                City = "Texas",
                Email = "dean@yaho.com",
                Phone = "13332",
                TeamId = 1
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 102,
                Name = "Mike",
                LastName = "Joe",
                Address = "Washington boulevar 3",
                City = "Washington",
                Email = "ron123@ms.com",
                Phone = "13332",
                TeamId = 2
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 103,
                Name = "Ron",
                LastName = "Scot",
                Address = "Washington boulevar 3",
                City = "Washington",
                Email = "mike@ms.com",
                Phone = "13333332",
                TeamId = 2
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 104,
                Name = "Dean",
                LastName = "Michael",
                Address = "Washington boulevar 3",
                City = "Washington",
                Email = "don.jonson@hr.com",
                Phone = "24343",
                TeamId = 2
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 105,
                Name = "Jack",
                LastName = "Jackson",
                Address = "La boulevar 3",
                City = "Los Angeles",
                Email = "john.doe@hr.com",
                Phone = "24343",
                TeamId = 3
            });
        }
    }
}
