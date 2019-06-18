using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Worker.Services;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerActiveJobDetailsPage : ContentPage
	{
		public EmployerActiveJobDetailsPage ()
		{
			InitializeComponent ();

            OpenUserProfileCommand = new Command<int>(OpenUserProfile);

            AcceptJobCommand = new Command<int>(AcceptJob);
            RejectJobCommand = new Command<int>(RejectJob);
            FinishJobCommand = new Command<int>(FinishJob);
            StartJobCommand = new Command<int>(StartJob);
        }

        public ICommand OpenUserProfileCommand { get; }
        private void OpenUserProfile(int userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            var user = job.Employees.First(employee => employee.Employee.Id == userId).Employee;
            var employeePage = new Employer_EmployeeProfilePage() { BindingContext = user };
            Navigation.PushAsync(employeePage);
        }

        public ICommand AcceptJobCommand { get; }
        private void AcceptJob(int userId)
        {
            var job = (EmployerJobViewModel) BindingContext;
            EmployerJobsService.AcceptByEmployer(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        public ICommand RejectJobCommand { get; }
        private void RejectJob(int userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            EmployerJobsService.RejectByEmployer(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        public ICommand FinishJobCommand { get; }
        private void FinishJob(int userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            EmployerJobsService.Finish(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        public ICommand StartJobCommand { get; }
        private void StartJob(int userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            EmployerJobsService.Start(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }

        private void StartLookingForEmployees(object sender, EventArgs e)
        {
            var job = (EmployerJobViewModel)BindingContext;
            job.IsLookingForNewEmployees = true;
            EmployerJobsService.StartLookingForNewEmployees(job.Id);
        }

        private void StopLookingForEmployees(object sender, EventArgs e)
        {
            var job = (EmployerJobViewModel)BindingContext;
            job.IsLookingForNewEmployees = false;
            EmployerJobsService.StopLookingForNewEmployees(job.Id);
        }

        private void CloseJob(object sender, EventArgs e)
        {
            var job = (EmployerJobViewModel)BindingContext;
            EmployerJobsService.CloseJob(job.Id);
            Navigation.PopAsync();
        }
    }
}