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
            Users = new List<UserModel>()
            {
                new EmployeeModel()
                {
                    Id = 0,
                    FirstName = "Анна",
                    LastName = "Паномаренко",
                    City = "Львів",
                    BirthDate = new DateTime(1996, 4, 10),
                    Photo = ImageSource.FromUri(new Uri(
                        "http://blogspay.com/wp-content/uploads/2018/07/istock-526142422.jpg")),
                    Phone = "093 125 31 51",
                    AverageRating = 4,
                    AboutMe = "",
                    Email = "anna",
                    IsVisible = true,
                    Password = "1",
                    JobTypes = new List<JobTypeModel>()
                    {
                        new JobTypeModel() {Id = 1, Name = "Діти"},
                        new JobTypeModel() {Id = 2, Name = "Прибирання"}
                    }
                },
                new EmployeeModel()
                {
                    Id = 1,
                    FirstName = "Остап",
                    LastName = "Шевченко",
                    City = "Київ",
                    BirthDate = new DateTime(1994, 12, 3),
                    Photo = ImageSource.FromUri(new Uri("https://www.jamestownsun.com/sites/default/files/styles/16x9_620/public/fieldimages/1/0927/1a7dwqhtwnbfimhbzydytkh71nl-pqa5s.jpg?itok=Dh7ajF49")),
                    Phone = "093 984 65 12",
                    AverageRating = 0,
                    AboutMe = "",
                    Email = "o",
                    IsVisible = true,
                    Password = "1",
                    JobTypes = new List<JobTypeModel>()
                    {
                        new JobTypeModel() {Id = 0, Name = "Вантажні роботи"},
                        new JobTypeModel() {Id = 2, Name = "Прибирання"},
                        new JobTypeModel() {Id = 3, Name = "Тварини"}
                    }
                },
                new EmployerModel()
                {
                    Id = 2,
                    FirstName = "Андрій",
                    LastName = "Тищенко",
                    City = "Львів",
                    BirthDate = new DateTime(1978, 1, 5),
                    Photo = ImageSource.FromUri(new Uri("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmUXsM8d3e7QSEdyB6gtrnxDb20n8aQdQTT9scz1MvLpaYgC5g")),
                    Phone = "093 152 12 52",
                    Company = "Softserve",
                    AverageRating = 4,
                    AboutMe = "",
                    Email = "a",
                    Password = "1"
                }
            };

            var employer = Get("andriy@gmail.com");
            employer.ReceivedReviews = new List<ReviewModel>()
            {
                new ReviewModel()
                {
                    Rating = 4,
                    Reviewer = UsersService.Get("ostap@gmail.com"),
                    Text =  "Було приємно працювати для Андрія. Робота була нескладна, оцінювава справедливо. Ніяких непорозумінь в роботі не виникло"
                }
            };

            var employee = Get("anna@gmail.com");
            employee.ReceivedReviews = new List<ReviewModel>()
            {
                new ReviewModel()
                {
                    Rating = 4,
                    Reviewer = UsersService.Get("andriy@gmail.com"),
                    Text =  "Анна показала себе як відповідальна і сумлінна людина. Роботу виконувала вчасно і якісно. Ніяких непорозуінь в роботі не було"
                }
            };
        }

        public static UserModel Get(string email)
        {
            // remove
            if (email == "andriy@gmail.com")
            {
                email = "a";
            } else if (email == "anna@gmail.com")
            {
                email = "anna";
            } else if (email == "ostap@gmail.com")
            {
                email = "o";
            }
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