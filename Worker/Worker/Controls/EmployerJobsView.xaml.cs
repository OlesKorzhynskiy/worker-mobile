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

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
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