using _11_SearchSortPagingDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_SearchSortPagingDAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source= .\\SQLEXPRESS;Initial Catalog=SearchSortPagingTaskDB;Integrated Security=True; Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add initial records to the database

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "IT" },
                new Department { DepartmentId = 2, Name = "HR" },
                new Department { DepartmentId = 3, Name = "Admin" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "Vishal", Address = "Pune", DepartmentId = 1 },
                new Employee { EmployeeId = 2, Name = "Akash", Address = "Mumbai", DepartmentId = 1 },
                new Employee { EmployeeId = 3, Name = "Shital", Address = "Pune", DepartmentId = 2 },
                new Employee { EmployeeId = 4, Name = "Suresh", Address = "Satara", DepartmentId = 2 },
                new Employee { EmployeeId = 5, Name = "Ramesh", Address = "Yavatmal", DepartmentId = 2 },
                new Employee { EmployeeId = 6, Name = "Geet", Address = "Pune", DepartmentId = 1 },
                new Employee { EmployeeId = 7, Name = "Suhas", Address = "Kalyan", DepartmentId = 1 },
                new Employee { EmployeeId = 8, Name = "Priyanka", Address = "Dhule", DepartmentId = 3 },
                new Employee { EmployeeId = 9, Name = "Snehal", Address = "Nashik", DepartmentId = 3 },
                new Employee { EmployeeId = 10, Name = "Dipika", Address = "Pune", DepartmentId = 3 },
                new Employee { EmployeeId = 11, Name = "Mahesh", Address = "Mumbai", DepartmentId = 3 }
            );
        }
    }
}
