using System;
using System.Collections.Generic;
using Worker.AutoMapper;
using Worker.Models;
using Worker.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Worker.Views;
using Worker.Views.Authentication;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Worker
{
    public partial class App : Application
    {
        public static UserModel User;

        public App()
        {
            InitializeComponent();

            Mapping.Initialize();

            MainPage = new SignInPage();
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
