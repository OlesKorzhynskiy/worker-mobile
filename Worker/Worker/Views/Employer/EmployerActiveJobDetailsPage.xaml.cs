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

            AcceptJobCommand = new Command<string>(AcceptJob);
            RejectJobCommand = new Command<string>(RejectJob);
            FinishJobCommand = new Command<string>(FinishJob);
            StartJobCommand = new Command<string>(StartJob);
        }

        public ICommand AcceptJobCommand { get; }
        private void AcceptJob(string userId)
        {
            var job = (EmployerJobViewModel) BindingContext;
            EmployerJobsService.AcceptByEmployer(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        public ICommand RejectJobCommand { get; }
        private void RejectJob(string userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            EmployerJobsService.RejectByEmployer(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        public ICommand FinishJobCommand { get; }
        private void FinishJob(string userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            EmployerJobsService.Finish(job.Id, userId);
            BindingContext = Mapper.Map<EmployerJobViewModel>(EmployerJobsService.Get(job.Id));
        }

        public ICommand StartJobCommand { get; }
        private void StartJob(string userId)
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