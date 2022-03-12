using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Models.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = 1, Email = "vrajshah363@gmail.com", Password = "Vraj1234" },
                    new Employee { Id = 2, Email = "shaansh2601@gmail.com", Password = "Shantanu1234" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
