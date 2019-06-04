using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
            job.JobType = job.JobTypes.First(jobType => jobType.Name == context.JobType.Name);
            var createJobPage = new EmployerCreateJobPage() { BindingContext = job };
            Navigation.PushAsync(createJobPage);
        }
    }
}