using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.PAN_Number)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
