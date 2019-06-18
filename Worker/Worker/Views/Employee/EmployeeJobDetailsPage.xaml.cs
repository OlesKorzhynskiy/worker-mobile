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
using Worker.Views.Employer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employee
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeJobDetailsPage : ContentPage
	{
		public EmployeeJobDetailsPage ()
		{
			InitializeComponent ();

            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += OpenUserProfile;
            EmployerFrame.GestureRecognizers.Add(gestureRecognizer);
        }

        private void OpenUserProfile(object sender, EventArgs e)
        {
            var job = (EmployeeJobViewModel)BindingContext;
            var user = job.Employer;
            var employerPage = new Employee_EmployerProfilePage() { BindingContext = user };
            Navigation.PushAsync(employerPage);
        }

        private void AddReview(object sender, EventArgs e)
        {
            var addReviewPage = new AddReviewPage() { BindingContext = new ReviewViewModel() };
            addReviewPage.OnAddReview += OnReviewAdded;
            Navigation.PushAsync(addReviewPage);
        }

        private void OnReviewAdded(ReviewViewModel reviewViewModel)
        {
            var job = (EmployeeJobViewModel)BindingContext;
            job.Employer.ReceivedReviews.Insert(0, reviewViewModel);
            var review = Mapper.Map<ReviewModel>(reviewViewModel);
            EmployeeJobsService.AddReview(job.Id, review);
        }
    }
}