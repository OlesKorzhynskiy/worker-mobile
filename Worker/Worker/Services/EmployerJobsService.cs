using System;
using System.Collections.Generic;
using System.Linq;
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
                    Employer = new EmployerModel()
                    {
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        Company = "Softserve",
                        AverageRating = 4,
                        AboutMe = "some text asdf ljkdsafj me , wehere ai tell smth sabout gme very interstetng, adsklfjdksla sdn somer more infroarsaf",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        ReceivedReviews = new List<ReviewModel>()
                        {
                            new ReviewModel()
                            {
                                Rating = 3,
                                Text = "Після відвідання цього туру, лишолося багато приємних вражень. Серед переваг я можу виділити наступні: гарний сервіс, гарна природа і чисті номери. Серед недоліків: фвіфіваіб, фіа івафіафів і афівжаолждфвоіалдж",
                                Reviewer = new UserModel() {FirstName = "Сергій", LastName = "Шевченко", City = "Львів, Рясне",
                                    Photo = ImageSource.FromUri(new Uri("https://jbwebanalytics.com/wp-content/uploads/2015/11/Brian-Toomey.png"))
                                },
                                Date = DateTime.Now
                            },
                            new ReviewModel()
                            {
                                Rating = 4,
                                Text = "Після відвідання цього туру, лишолося багато приємних вражень.",
                                Reviewer = new UserModel() {FirstName = "Оля", LastName = "Ровінська", City = "Львів, Рясне",
                                    Photo = ImageSource.FromUri(new Uri("https://www.unitedagents.co.uk/sites/default/files/styles/client_thumb_400x400/public/thumbnails/image/Headshot%201.PNG?itok=kHVT8TNT&c=277a71a7cdf9a41c57ff520dc593f271"))
                                },
                                Date = new DateTime(2017, 11, 25)
                            },
                        },
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50,
                    Employees = new List<JobUserModel>()
                    {
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {Id = "0", FirstName = "oles", BirthDate = new DateTime(1998, 5, 2), City = "Львів",
                                AverageRating = 4,
                                JobTypes = new List<JobTypeModel>()
                                {
                                    new JobTypeModel() {Id = 0, Name = "Вантажні роботи"},
                                    new JobTypeModel() {Id = 1, Name = "Діти"},
                                    new JobTypeModel() {Id = 2, Name = "Прибирання"},
                                },
                                AboutMe = "some text asdf ljkdsafj me , wehere ai tell smth sabout gme very interstetng, adsklfjdksla sdn somer more infroarsaf",
                                LastName = "Петренко",
                                Phone = "094 12 12 4",
                                ReceivedReviews = new List<ReviewModel>()
                                {
                                    new ReviewModel()
                                    {
                                        Rating = 3,
                                        Text = "Після відвідання цього туру, лишолося багато приємних вражень. Серед переваг я можу виділити наступні: гарний сервіс, гарна природа і чисті номери. Серед недоліків: фвіфіваіб, фіа івафіафів і афівжаолждфвоіалдж",
                                        Reviewer = new UserModel() {FirstName = "Сергій", LastName = "Шевченко", City = "Львів, Рясне",
                                            Photo = ImageSource.FromUri(new Uri("https://jbwebanalytics.com/wp-content/uploads/2015/11/Brian-Toomey.png"))
                                        },
                                        Date = DateTime.Now
                                    },
                                    new ReviewModel()
                                    {
                                        Rating = 4,
                                        Text = "Після відвідання цього туру, лишолося багато приємних вражень.",
                                        Reviewer = new UserModel() {FirstName = "Оля", LastName = "Ровінська", City = "Львів, Рясне",
                                            Photo = ImageSource.FromUri(new Uri("ps://www.unitedagents.co.uk/sites/default/files/styles/client_thumb_400x400/public/thumbnails/image/Headshot%201.PNG?itok=kHVT8TNT&c=277a71a7cdf9a41c57ff520dc593f271"))
                                        },
                                        Date = new DateTime(2017, 11, 25)
                                    },
                                },
                                Photo = ImageSource.FromUri(new Uri("https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A"))
                            },
                            Status = StatusEnum.InProgress
                        },
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {Id = "1", FirstName = "oles", BirthDate = new DateTime(1998, 5, 2), City = "Львів", AverageRating = 4,
                                JobTypes = new List<JobTypeModel>()
                                {
                                    new JobTypeModel() {Id = 0, Name = "Вантажні роботи"}
                                },
                                Photo = ImageSource.FromUri(new Uri("https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A"))
                            },
                            Status = StatusEnum.WaitingForEmployerConfirmation
                        },
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {Id = "2", FirstName = "oles", BirthDate = new DateTime(1998, 5, 2), City = "Львів", AverageRating = 4,
                                Photo = ImageSource.FromUri(new Uri("https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A"))
                            },
                            Status = StatusEnum.WaitingForEmployeeConfirmation
                        },
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {Id = "3", FirstName = "oles", BirthDate = new DateTime(1998, 5, 2), City = "Львів", AverageRating = 4,
                                Photo = ImageSource.FromUri(new Uri("https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A"))
                            },
                            Status = StatusEnum.Removed
                        }
                    }
                },
                new EmployerJobModel()
                {
                    Id = 1,
                    Description = "Посидіти з моєю дитиною",
                    StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван1",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50,
                    Employees = new List<JobUserModel>()
                    {
                        new JobUserModel()
                        {
                            Employee = new EmployeeModel() {Id = "0", FirstName = "oles"},
                            Status = StatusEnum.Done
                        }
                    }
                },
                new EmployerJobModel()
                {
                    Id = 2,
                    Description = "Посидіти з моєю дитиною",
                    StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                },
                new EmployerJobModel()
                {
                    Id = 3,
                    Description = "Посидіти з моєю дитиною",
                    StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                },
                new EmployerJobModel()
                {
                    Id = 4,
                    Description = "Посидіти з моєю дитиною",
                    StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                },
                new EmployerJobModel()
                {
                    Id = 5,
                    Description = "Посидіти з моєю дитиною",
                    StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                },
                new EmployerJobModel()
                {
                    Id = 6,
                    Description = "Посидіти з моєю дитиною",
                    StartDate = DateTime.Now,
                    Employer = new EmployerModel()
                    {
                        AverageRating = 4,
                        BirthDate = new DateTime(1985, 2, 4),
                        City = "Львів",
                        FirstName = "Іван",
                        LastName = "Петренко",
                        Phone = "094 12 12 4",
                        Photo = ImageSource.FromUri(new Uri("https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"))
                    },
                    JobType = new JobTypeModel() { Id = 0, Name = "Вантажні роботи" },
                    Name = "Сидіти з дитиною",
                    Duration = new TimeSpan(2, 0, 0),
                    Rate = 50
                }
            };
        }

        public static void AddReview(int jobId, string userId, ReviewModel review)
        {
            var job = Jobs.First(j => j.Id == jobId);
            if (job != null)
            {
                job.Employees.First(employee => employee.Employee.Id == userId).Employee.ReceivedReviews.Insert(0, review);
            }
        }

        public static void Add(EmployerJobModel job)
        {
            Jobs.Insert(0, job);
        }

        public static EmployerJobModel Get(int id)
        {
            return Jobs.First(j => j.Id == id);
        }

        public static List<EmployerJobModel> GetActive()
        {
            return Jobs.Where(job => !job.IsClosed).ToList();
        }

        public static List<EmployerJobModel> GetDone()
        {
            return Jobs.Where(job => job.IsClosed).ToList();
        }

        public static void AcceptByEmployer(int jobId, string userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.WaitingForEmployeeConfirmation;
            }
        }

        public static void RejectByEmployer(int jobId, string userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.RejectedByEmployer;
            }
        }

        public static void Finish(int jobId, string userId)
        {
            var job = Jobs.First(j => j.Id == jobId);
            var employee = job?.Employees.First(e => e.Employee.Id == userId);
            if (employee != null)
            {
                employee.Status = StatusEnum.Done;
            }
        }

        public static void Start(int jobId, string userId)
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