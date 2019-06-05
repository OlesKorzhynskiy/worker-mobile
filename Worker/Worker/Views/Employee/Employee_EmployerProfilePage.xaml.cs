using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employee
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Employee_EmployerProfilePage : ContentPage
	{
		public Employee_EmployerProfilePage ()
		{
			InitializeComponent ();
		}

        private void OnReviewsPage(object sender, EventArgs e)
        {
            var user = (EmployerViewModel)BindingContext;
            var reviewsPage = new ReviewsPage() { BindingContext = user.ReceivedReviews };
            Navigation.PushAsync(reviewsPage);
        }
    }
}