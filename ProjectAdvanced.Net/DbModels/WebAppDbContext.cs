using Microsoft.EntityFrameworkCore;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAdvanced.Net.DbModels
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> TblEmployees { get; set; }
        public DbSet<TimeReport> TblTimereports { get; set; }
        public DbSet<Project> TblProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //seed data
            //EMPLOYEES
            modelBuilder.Entity<Employee>().
                HasData
                (new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Edwin",
                    LastName = "Westerberg",
                    PersonalNumber = "941201293"

                });
            modelBuilder.Entity<Employee>().
                HasData
                (new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Test",
                    LastName = "Testsson",
                    PersonalNumber = "82314284"

                });
            modelBuilder.Entity<Employee>().
                HasData
                (new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Prov",
                    LastName = "Provsson",
                    PersonalNumber = "137583589"

                });
            modelBuilder.Entity<Employee>().
                HasData
                (new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Pröv",
                    LastName = "Prövsson",
                    PersonalNumber = "8491284824"

                });
            modelBuilder.Entity<Employee>().
                HasData
                (new Employee
                {
                    EmployeeId = 5,
                    FirstName = "Sara",
                    LastName = "Karlsson",
                    PersonalNumber = "853948392"

                });

            //PROJECT
            modelBuilder.Entity<Project>().
                HasData
                (new Project
                {
                    ProjectId = 1,
                    ProjectDescription = "Projekt1"

                });
            modelBuilder.Entity<Project>().
                HasData
                (new Project
                {
                    ProjectId = 2,
                    ProjectDescription = "Projekt2"

                });
            
            //TIMEREPORT DATA
            modelBuilder.Entity<TimeReport>().
                HasData
                (new TimeReport
                {
                    Id = 1,
                    Week = 1,
                    WorkHours = 40,
                    EmployeeId = 5,
                    ProjectId = 2

                });
            modelBuilder.Entity<TimeReport>().
                HasData
                (new TimeReport
                {
                    Id = 2,
                    Week = 2,
                    WorkHours = 40,
                    EmployeeId = 4,
                    ProjectId = 2

                });
            modelBuilder.Entity<TimeReport>().
                HasData
                (new TimeReport
                {
                    Id = 3,
                    Week = 3,
                    WorkHours = 50,
                    EmployeeId = 3,
                    ProjectId = 1

                });
            modelBuilder.Entity<TimeReport>().
                HasData
                (new TimeReport
                {
                    Id = 4,
                    Week = 4,
                    WorkHours = 40,
                    EmployeeId = 5,
                    ProjectId = 1

                });
            modelBuilder.Entity<TimeReport>().
                HasData
                (new TimeReport
                {
                    Id = 5,
                    Week = 5,
                    WorkHours = 60,
                    EmployeeId = 4,
                    ProjectId = 2

                });
            modelBuilder.Entity<TimeReport>().
                HasData
                (new TimeReport
                {
                    Id = 6,
                    Week = 4,
                    WorkHours = 40,
                    EmployeeId = 2,
                    ProjectId = 1

                });



        }
    }
}
