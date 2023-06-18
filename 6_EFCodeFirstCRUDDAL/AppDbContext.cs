using _6_EFCodeFirstCRUDDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace _6_EFCodeFirstCRUDDAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\\SQLEXPRESS;Initial Catalog=EFCodeFirstTaskDB;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}
