using System;
using Worker.Models;
using Worker.Views.Employee;
using Worker.Views.Employer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (IsEmployee)
            {
                var dashboardPage = new NavigationPage(new EmployeeDashboardTabbedPage())
                {
                    Icon = new FileImageSource() { File = "profile.png" },
                    Title = "Доска"
                };
                TabbedPageMenu.Children.Add(dashboardPage);
                var profilePage = new NavigationPage(new EmployeeProfilePage())
                {
                    Icon = new FileImageSource() { File = "profile.png" },
                    Title = "Профайл"
                };
                TabbedPageMenu.Children.Add(profilePage);
                var settingsPage = new NavigationPage(new EmployeeSettingsPage())
                {
                    Icon = new FileImageSource() { File = "settings.png" },
                    Title = "Налаштування"
                };
                TabbedPageMenu.Children.Add(settingsPage);
            }

            if (IsEmployer)
            {
                var profilePage = new NavigationPage(new EmployerProfilePage())
                {
                    Icon = new FileImageSource() { File = "profile.png" },
                    Title = "Профайл"
                };
                TabbedPageMenu.Children.Add(profilePage);
                var settingsPage = new NavigationPage(new EmployerSettingsPage())
                {
                    Icon = new FileImageSource() { File = "settings.png" },
                    Title = "Налаштування"
                };
                TabbedPageMenu.Children.Add(settingsPage);
            }
        }

        public bool IsEmployee => App.User.GetType() == typeof(EmployeeModel);
        public bool IsEmployer => App.User.GetType() == typeof(EmployerModel);
    }
}