using System;
using System.Collections.Generic;
using System.Linq;
using Worker.Enums;
using Worker.Models;
using Xamarin.Forms;

namespace Worker.Services
{
    public static class EmployeeJobsService
    {
        public static List<EmployeeJobModel> Jobs { get; set; }

        static EmployeeJobsService()
        {
            Jobs = new List<EmployeeJobModel>()
            {
                new EmployeeJobModel() {Id = 0, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.WaitingForEmployee, Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployeeJobModel() {Id = 1, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.WaitingForEmployerConfirmation, Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployeeJobModel() {Id = 2, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.WaitingForEmployeeConfirmation, Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployeeJobModel() {Id = 3, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.RejectedByEmployer, Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployeeJobModel() {Id = 4, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.RejectedByEmployee, Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployeeJobModel() {Id = 5, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.InProgress, Duration = new TimeSpan(2, 0, 0), Rate = 50
                },
                new EmployeeJobModel() {Id = 6, Description = "Посидіти з моєю дитиною", StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    }, JobType = new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}, Name = "Сидіти з дитиною", Status = StatusEnum.Done, Duration = new TimeSpan(2, 0, 0), Rate = 50
                }
            };
        }

        public static List<EmployeeJobModel> GetNew()
        {
            return Jobs.Where(job => job.Status == StatusEnum.WaitingForEmployee).ToList();
        }

        public static List<EmployeeJobModel> GetMy()
        {
            return Jobs.Where(job => job.Status != StatusEnum.WaitingForEmployee && job.Status != StatusEnum.Done && job.Status != StatusEnum.Removed).ToList();
        }

        public static List<EmployeeJobModel> GetDone()
        {
            return Jobs.Where(job => job.Status == StatusEnum.Done).ToList();
        }

        public static void AddReview(int id, ReviewModel review)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Employer.ReceivedReviews.Insert(0, review);
            }
        }

        public static void Remove(int id)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Status = StatusEnum.Removed;
            }
        }

        public static void Return(int id)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Status = StatusEnum.WaitingForEmployee;
            }
        }

        public static void Apply(int id)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Status = StatusEnum.WaitingForEmployerConfirmation;
            }
        }

        public static void RejectByEmployee(int id)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Status = StatusEnum.RejectedByEmployee;
            }
        }

        public static void AcceptByEmployee(int id)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Status = StatusEnum.InProgress;
            }
        }
    }
}