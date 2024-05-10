using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.AccessData
{
    public class RookieDBContext : DbContext
    {
        public RookieDBContext(DbContextOptions<RookieDBContext> options) : base(options)
        {
        }
        public RookieDBContext()
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });
            modelBuilder.Entity<Project>()
                .HasCheckConstraint("CK_Project_StartDate_EndDate", "StartDate < EndDate");
            //i want to add a check constraint to ensure that the salary amount is greater than 0
            modelBuilder.Entity<Salary>()
                .HasCheckConstraint("CK_Salary_Amount", "Amount > 0");

            //Seed data for all tables
            var departments = new List<Department>()
            {
                new Department { Id = 1, Name = "Software Development", Location="Hanoi" },
                new Department { Id = 2, Name = "Finance", Location = "Danang" },
                new Department { Id = 3, Name = "Accountant", Location = "Hanoi" },
                new Department { Id = 4, Name = "Human Resource", Location = "HCM" }
            };
            modelBuilder.Entity<Department>().HasData(departments);

            var employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Employee 1",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Address = "Address 1",
                    Email = "email1@example.com",
                    Phone = "1234567890",
                    JoinDate = new DateTime(2000, 12, 30),
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 2,
                    Name = "Employee 2",
                    DateOfBirth = new DateTime(1991, 2, 2),
                    Address = "Address 2",
                    Email = "email2@example.com",
                    Phone = "1234567891",
                    JoinDate = new DateTime(2002, 11, 29),
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 3,
                    Name = "Employee 3",
                    DateOfBirth = new DateTime(1992, 3, 3),
                    Address = "Address 3",
                    Email = "email3@example.com",
                    Phone = "1234567892",
                    JoinDate = new DateTime(2003, 10, 28),
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 4,
                    Name = "Employee 4",
                    DateOfBirth = new DateTime(1993, 4, 4),
                    Address = "Address 4",
                    Email = "email4@example.com",
                    Phone = "1234567893",
                    JoinDate = new DateTime(2004, 9, 27),
                    DepartmentId = 4,
                },
                new Employee
                {Id = 5,
                    Name = "Employee 5",
                    DateOfBirth = new DateTime(1994, 5, 5),
                    Address = "Address 5",
                    Email = "email5@example.com",
                    Phone = "1234567894",
                    JoinDate = new DateTime(2005, 8, 26),
                    DepartmentId = 1,
                },
                new Employee
                {
                    Id = 6,
                    Name = "Employee 6",
                    DateOfBirth = new DateTime(1995, 6, 6),
                    Address = "Address 6",
                    Email = "email6@example.com",
                    Phone = "1234567895",
                    JoinDate = new DateTime(2006, 7, 25),
                    DepartmentId = 2,
                },
                new Employee
                {Id = 7,
                    Name = "Employee 7",
                    DateOfBirth = new DateTime(1996, 7, 7),
                    Address = "Address 7",
                    Email = "email7@example.com",
                    Phone = "1234567896",
                    JoinDate = new DateTime(2007, 6, 24),
                    DepartmentId = 3,
                },
                new Employee
                {Id = 8,
                    Name = "Employee 8",
                    DateOfBirth = new DateTime(1997, 8, 8),
                    Address = "Address 8",
                    Email = "email8@example.com",
                    Phone = "1234567897",
                    JoinDate = new DateTime(2008, 5, 23),
                    DepartmentId = 4,
                },
                new Employee
                {Id = 9,
                    Name = "Employee 9",
                    DateOfBirth = new DateTime(1998, 9, 9),
                    Address = "Address 9",
                    Email = "email9@example.com",
                    Phone = "1234567898",
                    JoinDate = new DateTime(2009, 4, 22),
                    DepartmentId = 1,
                },
                new Employee
                {Id = 10,
                    Name = "Employee 10",
                    DateOfBirth = new DateTime(1999, 10, 10),
                    Address = "Address 10",
                    Email = "email10@example.com",
                    Phone = "1234567899",
                    JoinDate = new DateTime(2010, 3, 21),
                    DepartmentId = 2,
                },
                new Employee
                {Id = 11,
                    Name = "Employee 11",
                    DateOfBirth = new DateTime(2000, 11, 11),
                    Address = "Address 11",
                    Email = "email11@example.com",
                    Phone = "1234567800",
                    JoinDate = new DateTime(2011, 2, 20),
                    DepartmentId = 3,
                },
                new Employee
                {Id = 12,
                    Name = "Employee 12",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    Address = "Address 12",
                    Email = "email12@example.com",
                    Phone = "1234567801",
                    JoinDate = new DateTime(2012, 1, 19),
                    DepartmentId = 4,
                },
                new Employee
                {Id = 13,
                    Name = "Employee 13",
                    DateOfBirth = new DateTime(2002, 1, 13),
                    Address = "Address 13",
                    Email = "email13@example.com",
                    Phone = "1234567802",
                    JoinDate = new DateTime(2013, 12, 18),
                    DepartmentId = 1,
                },
                new Employee
                {Id = 14,
                    Name = "Employee 14",
                    DateOfBirth = new DateTime(2003, 2, 14),
                    Address = "Address 14",
                    Email = "email14@example.com",
                    Phone = "1234567803",
                    JoinDate = new DateTime(2014, 11, 17),
                    DepartmentId = 2,
                },
                new Employee
                {Id = 15,
                    Name = "Employee 15",
                    DateOfBirth = new DateTime(2004, 3, 15),
                    Address = "Address 15",
                    Email = "email15@example.com",
                    Phone = "1234567804",
                    JoinDate = new DateTime(2015, 10, 16),
                    DepartmentId = 3,
                }
            };
            modelBuilder.Entity<Employee>().HasData(employees);

            var salaries = new List<Salary>
            {
                new Salary { Id=1, Amount = 50000, EmployeeId = 1 },
                new Salary { Id=15, Amount = 60000, EmployeeId = 2 },
                new Salary { Id=2, Amount = 55000, EmployeeId = 3 },
                new Salary { Id=3, Amount = 58000, EmployeeId = 4 },
                new Salary { Id=4, Amount = 52000, EmployeeId = 5 },
                new Salary { Id=5, Amount = 53000, EmployeeId = 6 },
                new Salary { Id=6, Amount = 56000, EmployeeId = 7 },
                new Salary { Id=7, Amount = 57000, EmployeeId = 8 },
                new Salary { Id=8, Amount = 54000, EmployeeId = 9 },
                new Salary { Id=9, Amount = 59000, EmployeeId = 10 },
                new Salary { Id=10, Amount = 62000, EmployeeId = 11 },
                new Salary { Id=11, Amount = 61000, EmployeeId = 12 },
                new Salary { Id=12, Amount = 57000, EmployeeId = 13 },
                new Salary { Id=13, Amount = 56000, EmployeeId = 14 },
                new Salary { Id=14, Amount = 60000, EmployeeId = 15 },
            };
            modelBuilder.Entity<Salary>().HasData(salaries);


            var projects = new List<Project>() {
                new Project
                {
                    Id = 1,
                    Name = "Project 1",
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 6, 30),
                    Status = "New",
                    Description = "Description for Project 1",
                },
                new Project
                {
                    Id = 2,
                    Name = "Project 2",
                    StartDate = new DateTime(2023, 2, 15),
                    EndDate = new DateTime(2023, 8, 15),
                    Status = "In Progress",
                    Description = "Description for Project 2",
                },
                new Project
                {
                    Id = 3,
                    Name = "Project 3",
                    StartDate = new DateTime(2023, 3, 10),
                    EndDate = new DateTime(2023, 9, 30),
                    Status = "Completed",
                    Description = "Description for Project 3",
                }
            };
            modelBuilder.Entity<Project>().HasData(projects);

            var projectEmployees = new List<ProjectEmployee>()
            {
                new ProjectEmployee { ProjectId = 1, EmployeeId = 5, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 6, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 7, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 8, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 9, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 10, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 11, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 12, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 13, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 6, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 14, IsWorking = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 1, IsWorking = false },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 1, IsWorking = true },
                new ProjectEmployee { ProjectId = 3, EmployeeId = 1, IsWorking = true },
            };
            modelBuilder.Entity<ProjectEmployee>().HasData(projectEmployees);
        }
    }
}
