﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _11_SearchSortPagingDAL;

#nullable disable

namespace _11_SearchSortPagingDAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230621142424_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_11_SearchSortPagingDAL.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Name = "IT"
                        },
                        new
                        {
                            DepartmentId = 2,
                            Name = "HR"
                        },
                        new
                        {
                            DepartmentId = 3,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("_11_SearchSortPagingDAL.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Address = "Pune",
                            DepartmentId = 1,
                            Name = "Vishal"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Address = "Mumbai",
                            DepartmentId = 1,
                            Name = "Akash"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Address = "Pune",
                            DepartmentId = 2,
                            Name = "Shital"
                        },
                        new
                        {
                            EmployeeId = 4,
                            Address = "Satara",
                            DepartmentId = 2,
                            Name = "Suresh"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Address = "Yavatmal",
                            DepartmentId = 2,
                            Name = "Ramesh"
                        },
                        new
                        {
                            EmployeeId = 6,
                            Address = "Pune",
                            DepartmentId = 1,
                            Name = "Geet"
                        },
                        new
                        {
                            EmployeeId = 7,
                            Address = "Kalyan",
                            DepartmentId = 1,
                            Name = "Suhas"
                        },
                        new
                        {
                            EmployeeId = 8,
                            Address = "Dhule",
                            DepartmentId = 3,
                            Name = "Priyanka"
                        },
                        new
                        {
                            EmployeeId = 9,
                            Address = "Nashik",
                            DepartmentId = 3,
                            Name = "Snehal"
                        },
                        new
                        {
                            EmployeeId = 10,
                            Address = "Pune",
                            DepartmentId = 3,
                            Name = "Dipika"
                        },
                        new
                        {
                            EmployeeId = 11,
                            Address = "Mumbai",
                            DepartmentId = 3,
                            Name = "Mahesh"
                        });
                });

            modelBuilder.Entity("_11_SearchSortPagingDAL.Entities.Employee", b =>
                {
                    b.HasOne("_11_SearchSortPagingDAL.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
