using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LaavorRatingSwap;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddReviewPage : ContentPage
	{
        public delegate void AddReviewEventHandler(ReviewViewModel review);
        public event AddReviewEventHandler OnAddReview;

        public AddReviewPage()
        {
            InitializeComponent();
        }

        private void RatingImage_OnSelect(object sender, EventArgs e)
        {
            ((ReviewViewModel)BindingContext).Rating = ((RatingImage)sender).Value;
        }

        private void OnAddReviewClick(object sender, EventArgs e)
        {
            var review = (ReviewViewModel)BindingContext;
            review.Date = DateTime.Now;
            review.Reviewer = Mapper.Map<UserViewModel>(App.User);
            OnAddReview?.Invoke(review);
            Navigation.PopAsync();
        }
    }
}