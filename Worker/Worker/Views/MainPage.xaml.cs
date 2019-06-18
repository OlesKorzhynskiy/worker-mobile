using System;
using AutoMapper;
using Worker.Models;
using Worker.Services;
using Worker.ViewModels;
using Worker.Views.Employee;
using Worker.Views.Employer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(bool editPage = false)
        {
            InitializeComponent();

            if (IsEmployee)
            {
                // set begginning statuses
                EmployeeJobsService.SetDefaultStatuses();

                var dashboardPage = new NavigationPage(new EmployeeDashboardTabbedPage())
                {
                    Icon = new FileImageSource() { File = "profile.png" },
                    Title = "Дошка"
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

                if (editPage)
                {
                    Navigation.PushAsync(new EmployeeEditProfilePage() { BindingContext = Mapper.Map<EmployeeViewModel>(App.User) });
                }
            }

            if (IsEmployer)
            {
                var dashboardPage = new NavigationPage(new EmployerDashboardTabbedPage())
                {
                    Icon = new FileImageSource() { File = "profile.png" },
                    Title = "Дошка"
                };
                TabbedPageMenu.Children.Add(dashboardPage);
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

                if (editPage)
                {
                    Navigation.PushAsync(new EmployerEditProfilePage() { BindingContext = Mapper.Map<EmployerViewModel>(App.User) });
                }
            }
        }

        public bool IsEmployee => App.User.GetType() == typeof(EmployeeModel);
        public bool IsEmployer => App.User.GetType() == typeof(EmployerModel);
    }
}