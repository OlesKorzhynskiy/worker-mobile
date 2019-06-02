using System;
using System.Collections.Generic;
using System.Linq;
using Worker.Enums;
using Worker.Models;

namespace Worker.Services
{
    public static class EmployerJobsService
    {
        public static List<EmployerJobModel> Jobs { get; set; }

        static EmployerJobsService()
        {
            Jobs = new List<EmployerJobModel>()
            {
                new EmployerJobModel() {Id = 0, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50,
                    Employees = new List<JobUserModel>()
                    {
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {FirstName = "oles"},
                            Status = StatusEnum.InProgress
                        }
                    }
                },
                new EmployerJobModel() {Id = 1, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван1",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50,
                    Employees = new List<JobUserModel>()
                    {
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {FirstName = "oles"},
                            Status = StatusEnum.Done
                        }
                    }
                },
                new EmployerJobModel() {Id = 2, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployerJobModel() {Id = 3, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployerJobModel() {Id = 4, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployerJobModel() {Id = 5, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployerJobModel() {Id = 6, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Duration = new TimeSpan(2, 0, 0), Rate = 50
                }
            };
        }

        public static List<EmployerJobModel> GetActive()
        {
            return Jobs.Where(job => job.Employees.Count == 0 || job.Employees.Exists(jobEmployee => jobEmployee.Status != StatusEnum.Done)).ToList();
        }

        public static List<EmployerJobModel> GetDone()
        {
            return Jobs.Where(job => job.Employees.Count != 0 && job.Employees.All(jobEmployee => jobEmployee.Status == StatusEnum.Done)).ToList();
        }
    }
}