using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Worker.Models;
using Worker.Services;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerClosedJobDetailsPage : ContentPage
	{
		public EmployerClosedJobDetailsPage ()
		{
			InitializeComponent ();

            OpenUserProfileCommand = new Command<int>(OpenUserProfile);
            AddReviewCommand = new Command<int>(AddReview);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }

        private void OnCreateJob(object sender, EventArgs e)
        {
            var context = (EmployerJobViewModel) BindingContext;
            var job = Mapper.Map< EmployerJobViewModel>(EmployerJobsService.Get(context.Id));
            job.StartDate = DateTime.Now;
            job.Employees = new List<JobUserViewModel>();
            job.IsClosed = false;
            job.IsLookingForNewEmployees = true;
            job.JobType = job.JobTypes.First(jobType => jobType.Name == context.JobType.Name);
            var createJobPage = new EmployerCreateJobPage() { BindingContext = job };
            Navigation.PushAsync(createJobPage);
        }

        public ICommand OpenUserProfileCommand { get; }
        private void OpenUserProfile(int userId)
        {
            var job = (EmployerJobViewModel)BindingContext;
            var user = job.Employees.First(employee => employee.Employee.Id == userId).Employee;
            var employeePage = new Employer_EmployeeProfilePage() { BindingContext = user };
            Navigation.PushAsync(employeePage);
        }

        private int _employeeId;
        public ICommand AddReviewCommand { get; }
        private void AddReview(int employeeId)
        {
            var addReviewPage = new AddReviewPage() { BindingContext = new ReviewViewModel() };
            _employeeId = employeeId;
            addReviewPage.OnAddReview += OnReviewAdded;
            Navigation.PushAsync(addReviewPage);
        }

        private void OnReviewAdded(ReviewViewModel reviewViewModel)
        {
            var job = (EmployerJobViewModel) BindingContext;
            job.Employees.First(employee => employee.Employee.Id == _employeeId).Employee.ReceivedReviews.Insert(0, reviewViewModel);
            var review = Mapper.Map<ReviewModel>(reviewViewModel);
            EmployerJobsService.AddReview(job.Id, _employeeId, review);
        }
    }
}