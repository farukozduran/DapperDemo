using Microsoft.EntityFrameworkCore;
using DapperDemo.Models;

namespace DapperDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().Ignore(t => t.Employees);

            modelBuilder.Entity<Employee>().HasOne(c => c.Company).WithMany(e => e.Employees).HasForeignKey(e => e.CompanyId);
        }
    }
}
