using System;
using System.Collections.Generic;
using System.Linq;
using Worker.Models;
using Xamarin.Forms;

namespace Worker.Services
{
    public static class UsersService
    {
        public static List<UserModel> Users { get; set; }

        static UsersService()
        {
            Users = new List<UserModel>();
            var employee = new EmployeeModel()
            {
                FirstName = "Ольга",
                LastName = "Ровінська",
                City = "Львів",
                BirthDate = new DateTime(1998, 4, 10),
                Photo = ImageSource.FromUri(new Uri("https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A")),
                Phone = "093 521 39 49",
                AverageRating = 4,
                AboutMe = "some text asdf ljkdsafj me , wehere ai tell smth sabout gme very interstetng, adsklfjdksla sdn somer more infroarsaf",
                Email = "employee@gmail.com",
                IsVisible = true,
                Password = "123456",
                JobTypes = new List<JobTypeModel>()
                {
                    new JobTypeModel() {Id = 0, Name = "Вантажні роботи"},
                    new JobTypeModel() {Id = 1, Name = "Діти"},
                },
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
                }
            };
            Users.Add(employee);

            var employer = new EmployerModel()
            {
                FirstName = "Ольга",
                LastName = "Ровінська",
                City = "Львів",
                BirthDate = new DateTime(1998, 4, 10),
                Photo = ImageSource.FromUri(new Uri("https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A")),
                Phone = "093 521 39 49",
                Company = "Softserve",
                AverageRating = 4,
                AboutMe = "some text asdf ljkdsafj me , wehere ai tell smth sabout gme very interstetng, adsklfjdksla sdn somer more infroarsaf",
                Email = "employer@gmail.com",
                Password = "123456",
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
                }
            };
            Users.Add(employer);
        }

        public static UserModel Get(string email)
        {
            return Users.FirstOrDefault(user => user.Email == email);
        }

        public static UserModel Add(UserModel user)
        {
            if (Users.Count > 0)
            {
                user.Id = Users.Max(u => u.Id) + 1;
            }
            else
            {
                user.Id = 0;
            }
            Users.Add(user);
            return user;
        }

        public static void AddReview(int id, ReviewModel review)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.ReceivedReviews.Add(review);
            }
        }
    }
}