using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employee
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeProfilePage : ContentPage
	{
		public EmployeeProfilePage()
		{
			InitializeComponent ();

            BindingContext = Mapper.Map<EmployeeViewModel>(App.User);
        }

        private void OnEditProfilePage(object sender, EventArgs e)
        {
            var newUser = (EmployeeViewModel)BindingContext;
            var editProfilePage = new EmployeeEditProfilePage() { BindingContext = newUser };
            Navigation.PushAsync(editProfilePage);
        }

        private void OnReviewsPage(object sender, EventArgs e)
        {
            var user = (EmployeeViewModel)BindingContext;
            var reviewsPage = new ReviewsPage() { BindingContext = user.ReceivedReviews };
            Navigation.PushAsync(reviewsPage);
        }

        protected override void OnAppearing()
        {
            BindingContext = Mapper.Map<EmployeeViewModel>(App.User);
        }
    }
}