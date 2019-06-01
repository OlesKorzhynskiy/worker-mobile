using System;
using Worker.AutoMapper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Worker.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Worker
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Mapping.Initialize();

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
