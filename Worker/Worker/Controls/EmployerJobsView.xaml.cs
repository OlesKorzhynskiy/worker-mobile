using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Worker.Models;
using Worker.Services;
using Worker.ViewModels;
using Worker.Views;
using Worker.Views.Employer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerJobsView : ContentView
	{
        public EmployerJobsView ()
		{
			InitializeComponent ();
        }

        public int JobsListViewHeight
        {
            get
            {
                var elements = (ObservableCollection<EmployerJobViewModel>) BindingContext;
                return elements?.Count * 100 ?? 0;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
                var job = (EmployerJobViewModel) e.SelectedItem;
                if (job.IsActive)
                {
                    var detailsPage = new EmployerActiveJobDetailsPage() { BindingContext = job };
                    Navigation.PushAsync(detailsPage);
                }
                else
                {
                    var detailsPage = new EmployerClosedJobDetailsPage() {BindingContext = job};
                    Navigation.PushAsync(detailsPage);
                }
            }
        }

        private void OnCreateJob(object sender, EventArgs e)
        {
            var employerJobViewModel = new EmployerJobViewModel {Employer = Mapper.Map<EmployerViewModel>(App.User)};
            var createJobPage = new EmployerCreateJobPage() {BindingContext = employerJobViewModel};
            Navigation.PushAsync(createJobPage);
        }
    }
}