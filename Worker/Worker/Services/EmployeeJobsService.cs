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
                    Description = "Посидіти з моєю дитиноюf kajsdkl;f;j skaldj fklsad jkl;f jksld;ajf klsdjalkfjsdkl;fjkl asdjkfl jew;kjfio jsdo;aj fk;jsd ;ofjweio;j f;ksdjakl fjsdaklj foewjoif jdsjk afkl;j ioewjfoi ewjafo jdskl;ajf kdsajf iowej pfjkdsj fkldsja fkjaofj weoipjf kjdsk ;fjk adsjfiewjpf ojsdklaj fklj",
                    StartDate = DateTime.Now,
                    Employer = (EmployerModel)UsersService.Get("employer@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Status = StatusEnum.WaitingForEmployee,
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                },
                new EmployeeJobModel()
                {
                    Id = 1,
                    Description = "Посидіти з моєю дитиноюf kajsdkl;f;j skaldj fklsad jkl;f jksld;ajf klsdjalkfjsdkl;fjkl asdjkfl jew;kjfio jsdo;aj fk;jsd ;ofjweio;j f;ksdjakl fjsdaklj foewjoif jdsjk afkl;j ioewjfoi ewjafo jdskl;ajf kdsajf iowej pfjkdsj fkldsja fkjaofj weoipjf kjdsk ;fjk adsjfiewjpf ojsdklaj fklj",
                    StartDate = DateTime.Now,
                    Employer = (EmployerModel)UsersService.Get("employer@gmail.com"),
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Status = StatusEnum.WaitingForEmployee,
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                }
            };
            /*{
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
            };*/
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
            return Jobs.Where(job => ((EmployeeModel)App.User).JobTypes.Find(j => j.Name == job.JobType.Name) != null);
        }
        public static List<EmployeeJobModel> GetNew()
        {
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