using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.ViewModels;
using Worker.Views.Authentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerProfilePage : ContentPage
	{
		public EmployerProfilePage ()
		{
			InitializeComponent ();

            BindingContext = Mapper.Map<EmployerViewModel>(App.User);
        }

        private void OnEditProfilePage(object sender, EventArgs e)
        {
            var newUser = (EmployerViewModel)BindingContext;
            var editProfilePage = new EmployerEditProfilePage() { BindingContext = newUser };
            Navigation.PushAsync(editProfilePage);
        }

        private void OnReviewsPage(object sender, EventArgs e)
        {
            var user = (EmployerViewModel)BindingContext;
            var reviewsPage = new ReviewsPage() { BindingContext = user.ReceivedReviews };
            Navigation.PushAsync(reviewsPage);
        }

        private void OnSignOut(object sender, EventArgs e)
        {
            App.User = null;
            App.Current.MainPage = new SignInPage();
        }

        protected override void OnAppearing()
        {
            BindingContext = Mapper.Map<EmployerViewModel>(App.User);
        }
    }
}