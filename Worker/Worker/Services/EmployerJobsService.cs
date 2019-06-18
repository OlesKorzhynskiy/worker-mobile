using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Worker.Enums;
using Worker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Worker.Services
{
    public static class EmployerJobsService
    {
        private static List<EmployerJobModel> Jobs { get; set; }

        static EmployerJobsService()
        {
            Jobs = new List<EmployerJobModel>()
            {
                new EmployerJobModel()
                {
                    Id = 0,
                    Name = "Розвантаження судна",
                    Description = "Потрібен чоловік для розвантаження пароплава в Одеському порті",
                    StartDate = DateTime.Now.AddDays(5),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Duration = new TimeSpan(3, 0, 0),
                    Rate = 50
                },
                new EmployerJobModel()
                {
                    Id = 1,
                    Name = "Перевезення і розвантаження продукції",
                    Description = "Потрібна людина з машиною для доставки речей у нову квартиру",
                    StartDate = DateTime.Now.AddDays(1),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Duration = new TimeSpan(8, 0, 0),
                    Rate = 50
                },
                new EmployerJobModel()
                {
                    Id = 2,
                    Name = "Догляд за дітьми",
                    Description = "Потрібна людина для догляду за 2 дітьми віку 8 і 10 років",
                    StartDate = DateTime.Now.AddDays(2),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 1, Name = "Діти"},
                    Duration = new TimeSpan(4, 0, 0),
                    Rate = 40
                },
                new EmployerJobModel()
                {
                    Id = 3,
                    Name = "Приватне навчання дітей на дому",
                    Description = "Потрібен викладач для дитини віком 12 років з точних предметів",
                    StartDate = DateTime.Now.AddDays(4),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 1, Name = "Діти"},
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 60
                },
                new EmployerJobModel()
                {
                    Id = 4,
                    Name = "Прибирання у квартирі",
                    Description = "Потрібна людина для прибирання у квартирі",
                    StartDate = DateTime.Now.AddDays(5),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 2, Name = "Прибирання"},
                    Duration = new TimeSpan(9, 0, 0),
                    Rate = 40
                },
                new EmployerJobModel()
                {
                    Id = 5,
                    Name = "Вигул тварин",
                    Description = "Потрібна людина для прогулки з 3 доберманами",
                    StartDate = DateTime.Now.AddDays(3),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 3, Name = "Тварини"},
                    Duration = new TimeSpan(1, 0, 0),
                    Rate = 40
                },
                new EmployerJobModel()
                {
                    Id = 6,
                    Name = "Догляд за тваринами",
                    Description = "Потрібна людина для догляду кішки і рибок у час відсутності господарів",
                    StartDate = DateTime.Now.AddDays(6),
                    Employer = (EmployerModel)UsersService.Get("andriy@gmail.com"),
                    JobType = new JobTypeModel() {Id = 3, Name = "Тварини"},
                    Duration = new TimeSpan(8, 0, 0),
                    Rate = 40
                }
            };
        }

        public static void AddReview(int jobId, int userId, ReviewModel review)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.Employees.First(employee => employee.Employee.Id == userId).Employee.ReceivedReviews.Insert(0, review);
                UsersService.AddReview(userId, review);
            }
        }

        public static void AddEmployee(int jobId, EmployeeModel employee)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.Employees.Add(new JobUserModel() {Employee = employee, Status = StatusEnum.WaitingForEmployerConfirmation});
            }
        }

        public static void RemoveEmployee(int jobId, int employeeId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.Employees.Remove(job.Employees.Find(employee => employee.Employee.Id == employeeId));
            }
        }

        public static void Add(EmployerJobModel job)
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
            var employeeJob = Mapper.Map<EmployeeJobModel>(job);
            employeeJob.Status = StatusEnum.WaitingForEmployee;
            EmployeeJobsService.Add(employeeJob);
        }

        public static EmployerJobModel Get(int id)
        {
            return Jobs.First(j => j.Id == id);
        }

        public static List<EmployerJobModel> GetActive()
        {
            return Jobs.Where(job => !job.IsClosed && job.Employer.Id == App.User.Id).ToList();
        }

        public static List<EmployerJobModel> GetDone()
        {
            return Jobs.Where(job => job.IsClosed && job.Employer.Id == App.User.Id).ToList();
        }

        public static StatusEnum GetStatus(int jobId, int userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.FirstOrDefault(e => e.Employee.Id == userId);
            if (employee != null)
            {
                return employee.Status;
            }

            return StatusEnum.WaitingForEmployee;
        }

        // set statuses
        public static void SetStatus(int jobId, int userId, StatusEnum status)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = status;
            }
        }

        public static void AcceptByEmployer(int jobId, int userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.WaitingForEmployeeConfirmation;
            }
        }

        public static void RejectByEmployer(int jobId, int userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.RejectedByEmployer;
            }
        }

        public static void Finish(int jobId, int userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.Done;
            }
        }

        public static void Start(int jobId, int userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.InProgress;
            }
        }

        public static void StopLookingForNewEmployees(int jobId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.IsLookingForNewEmployees = false;
            }
        }

        public static void StartLookingForNewEmployees(int jobId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.IsLookingForNewEmployees = false;
            }
        }

        public static void CloseJob(int jobId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.IsClosed = true;
                job.Employees.Where(employee => employee.Status == StatusEnum.InProgress).ForEach(employee => employee.Status = StatusEnum.Done);
            }
        }
    }
}