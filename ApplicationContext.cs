using Intership.Models;
using Microsoft.EntityFrameworkCore;

namespace Intership
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=Intership;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Market>? Markets { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<RegistrationData>? RegistrationDatas { get; set; }
        public DbSet<Employeess>? Employeesses { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Driver>? Drivers { get; set; }
        public DbSet<Order>? Orders { get; set; }
    }
}
