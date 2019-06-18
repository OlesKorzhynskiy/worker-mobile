using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Employer_EmployeeProfilePage : ContentPage
	{
		public Employer_EmployeeProfilePage ()
		{
			InitializeComponent ();
		}

        private void OnReviewsPage(object sender, EventArgs e)
        {
            var user = (EmployeeViewModel)BindingContext;
            var reviewsPage = new ReviewsPage() { BindingContext = user.ReceivedReviews };
            Navigation.PushAsync(reviewsPage);
        }
    }
}