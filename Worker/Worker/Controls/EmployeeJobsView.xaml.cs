using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Worker.Enums;
using Worker.Models;
using Worker.Services;
using Worker.ViewModels;
using Worker.Views;
using Worker.Views.Employee;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeJobsView : ContentView
    {
        private int currentJobId;

        public ICommand AddReviewCommand { get; }
        private void AddReview(int id)
        {
            var addReviewPage = new AddReviewPage() { BindingContext = new ReviewViewModel() };
            currentJobId = id;
            addReviewPage.OnAddReview += OnReviewAdded;
            Navigation.PushAsync(addReviewPage);
        }

        public EmployeeJobsView ()
		{
			InitializeComponent ();

            AddReviewCommand = new Command<int>(AddReview);
        }

        public int JobsListViewHeight
        {
            get
            {
                var elements = (ObservableCollection<EmployeeJobViewModel>)BindingContext;
                return elements?.Count * 110 ?? 0;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
                var job = (EmployeeJobViewModel)e.SelectedItem;
                var detailsPage = new EmployeeJobDetailsPage() { BindingContext = job };
                Navigation.PushAsync(detailsPage);
            }
        }

        private void OnReviewAdded(ReviewViewModel reviewViewModel)
        {
            var review = Mapper.Map<ReviewModel>(reviewViewModel);
            EmployeeJobsService.AddReview(currentJobId, review);
        }
    }
}