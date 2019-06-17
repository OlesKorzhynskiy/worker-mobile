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
                    Description = "Посидіти з моєю дитиноюf kajsdkl;f;j skaldj fklsad jkl;f jksld;ajf klsdjalkfjsdkl;fjkl asdjkfl jew;kjfio jsdo;aj fk;jsd ;ofjweio;j f;ksdjakl fjsdaklj foewjoif jdsjk afkl;j ioewjfoi ewjafo jdskl;ajf kdsajf iowej pfjkdsj fkldsja fkjaofj weoipjf kjdsk ;fjk adsjfiewjpf ojsdklaj fklj",
                    StartDate = DateTime.Now,
                    Employer = (EmployerModel)UsersService.Get("employer@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50,
                    Employees = new List<JobUserModel>()
                    {
                        new JobUserModel()
                        {
                            Employee = (EmployeeModel)UsersService.Get("employee@gmail.com"),
                            Status = StatusEnum.Done
                        }
                    }
                },
                new EmployerJobModel()
                {
                    Id = 1,
                    Description = "Посидіти з моєю дитиноюf kajsdkl;f;j skaldj fklsad jkl;f jksld;ajf klsdjalkfjsdkl;fjkl asdjkfl jew;kjfio jsdo;aj fk;jsd ;ofjweio;j f;ksdjakl fjsdaklj foewjoif jdsjk afkl;j ioewjfoi ewjafo jdskl;ajf kdsajf iowej pfjkdsj fkldsja fkjaofj weoipjf kjdsk ;fjk adsjfiewjpf ojsdklaj fklj",
                    StartDate = DateTime.Now,
                    Employer = (EmployerModel)UsersService.Get("employer@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50,
                    Employees = new List<JobUserModel>()
                    {
                        new JobUserModel()
                        {
                            Employee = (EmployeeModel)UsersService.Get("employee@gmail.com"),
                            Status = StatusEnum.WaitingForEmployee
                        }
                    }
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