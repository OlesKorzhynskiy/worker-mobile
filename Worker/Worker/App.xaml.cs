using System;
using System.Collections.Generic;
using Worker.AutoMapper;
using Worker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Worker.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Worker
{
    public partial class App : Application
    {
        public static EmployeeModel User;

        public App()
        {
            InitializeComponent();

            Mapping.Initialize();

            User = new EmployeeModel()
            {
                FirstName = "Ольга",
                LastName = "Ровінська",
                City = "Львів",
                BirthDate = new DateTime(1998, 4, 10),
                Photo = "https://media.licdn.com/dms/image/C5603AQGAzsg5qZRzzg/profile-displayphoto-shrink_200_200/0?e=1562803200&v=beta&t=WVi627qWCw58aEtQ2DI-jirm3WVdjQWLQCEvy4eOV1A",
                Phone = "093 521 39 49",
                AverageRating = 4,
                AboutMe = "some text asdf ljkdsafj me , wehere ai tell smth sabout gme very interstetng, adsklfjdksla sdn somer more infroarsaf",
                Email = "oles.korzhynskiy@gmail.com",
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
                        Reviewer = new UserModel() {FirstName = "Сергій", LastName = "Шевченко", City = "Львів, Рясне", Photo = "https://jbwebanalytics.com/wp-content/uploads/2015/11/Brian-Toomey.png" },
                        Date = DateTime.Now
                    },
                    new ReviewModel()
                    {
                        Rating = 4,
                        Text = "Після відвідання цього туру, лишолося багато приємних вражень.",
                        Reviewer = new UserModel() {FirstName = "Оля", LastName = "Ровінська", City = "Львів, Рясне", Photo = "https://www.unitedagents.co.uk/sites/default/files/styles/client_thumb_400x400/public/thumbnails/image/Headshot%201.PNG?itok=kHVT8TNT&c=277a71a7cdf9a41c57ff520dc593f271" },
                        Date = new DateTime(2017, 11, 25)
                    },
                }
            };

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
