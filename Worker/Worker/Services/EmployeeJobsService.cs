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
                new EmployeeJobModel()
                {
                    Id = 0,
                    Name = "Розвантаження судна",
                    Description = "Потрібен чоловік для розвантаження пароплава в Одеському порті",
                    StartDate = DateTime.Now.AddDays(5),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Duration = new TimeSpan(3, 0, 0),
                    Rate = 50,
                    Status = StatusEnum.WaitingForEmployee
                },
                new EmployeeJobModel()
                {
                    Id = 1,
                    Name = "Перевезення і розвантаження продукції",
                    Description = "Потрібна людина з машиною для доставки речей у нову квартиру",
                    StartDate = DateTime.Now.AddDays(1),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Duration = new TimeSpan(8, 0, 0),
                    Rate = 50,
                    Status = StatusEnum.WaitingForEmployee
                },
                new EmployeeJobModel()
                {
                    Id = 2,
                    Name = "Догляд за дітьми",
                    Description = "Потрібна людина для догляду за 2 дітьми віку 8 і 10 років",
                    StartDate = DateTime.Now.AddDays(2),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 1, Name = "Діти"},
                    Duration = new TimeSpan(4, 0, 0),
                    Rate = 40,
                    Status = StatusEnum.WaitingForEmployee
                },
                new EmployeeJobModel()
                {
                    Id = 3,
                    Name = "Приватне навчання дітей на дому",
                    Description = "Потрібен викладач для дитини віком 12 років з точних предметів",
                    StartDate = DateTime.Now.AddDays(4),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 1, Name = "Діти"},
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 60,
                    Status = StatusEnum.WaitingForEmployee
                },
                new EmployeeJobModel()
                {
                    Id = 4,
                    Name = "Прибирання у квартирі",
                    Description = "Потрібна людина для прибирання у квартирі",
                    StartDate = DateTime.Now.AddDays(5),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 2, Name = "Прибирання"},
                    Duration = new TimeSpan(9, 0, 0),
                    Rate = 40,
                    Status = StatusEnum.WaitingForEmployee
                },
                new EmployeeJobModel()
                {
                    Id = 5,
                    Name = "Вигул тварин",
                    Description = "Потрібна людина для прогулки з 3 доберманами",
                    StartDate = DateTime.Now.AddDays(3),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 3, Name = "Тварини"},
                    Duration = new TimeSpan(1, 0, 0),
                    Rate = 40,
                    Status = StatusEnum.WaitingForEmployee
                },
                new EmployeeJobModel()
                {
                    Id = 6,
                    Name = "Догляд за тваринами",
                    Description = "Потрібна людина для догляду кішки і рибок у час відсутності господарів",
                    StartDate = DateTime.Now.AddDays(6),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 3, Name = "Тварини"},
                    Duration = new TimeSpan(8, 0, 0),
                    Rate = 40,
                    Status = StatusEnum.WaitingForEmployee
                }
            };
        }

        public static void SetDefaultStatuses()
        {
            foreach (var job in Jobs)
            {
                if (job.Status != StatusEnum.Removed)
                {
                    job.Status = EmployerJobsService.GetStatus(job.Id, App.User.Id);
                }
            }
        }

        public static void Add(EmployeeJobModel job)
        {
            if (Jobs.Count > 0)
            {
                job.Id = Jobs.Max(j => j.Id) + 1;
            }
            else
            {
                job.Id = 0;
            }
            Jobs.Insert(0, job);
        }

        public static IEnumerable<EmployeeJobModel> GetByJobTypes()
        {
            return Jobs.Where(job => ((EmployeeModel)App.User).JobTypes.Find(j => j.Name == job.JobType.Name) != null && EmployerJobsService.Get(job.Id).IsLookingForNewEmployees);
        }
        public static List<EmployeeJobModel> GetNew()
        {
            if (((EmployeeModel) App.User).IsVisible)
            {
                return new List<EmployeeJobModel>();
            }
            return GetByJobTypes().Where(job => job.Status == StatusEnum.WaitingForEmployee).ToList();
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
                UsersService.AddReview(job.Employer.Id, review);
            }
        }

        // set statuses
        public static void Remove(int id)
        {
            SetStatus(id, StatusEnum.Removed);
            EmployerJobsService.RemoveEmployee(id, App.User.Id);
        }

        public static void Return(int id)
        {
            SetStatus(id, StatusEnum.WaitingForEmployee);
        }

        public static void Apply(int id)
        {
            SetStatus(id, StatusEnum.WaitingForEmployerConfirmation);
            EmployerJobsService.AddEmployee(id, (EmployeeModel)App.User);
        }

        public static void RejectByEmployee(int id)
        {
            SetStatus(id, StatusEnum.RejectedByEmployee);
            EmployerJobsService.SetStatus(id, App.User.Id, StatusEnum.RejectedByEmployee);
        }

        public static void AcceptByEmployee(int id)
        {
            SetStatus(id, StatusEnum.InProgress);
            EmployerJobsService.SetStatus(id, App.User.Id, StatusEnum.InProgress);
        }

        public static void SetStatus(int id, StatusEnum status)
        {
            var job = Jobs.First(j => j.Id == id);
            if (job != null)
            {
                job.Status = status;
            }
        }
    }
}