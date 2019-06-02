using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Models;
using Worker.Services;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerCreateJobPage : ContentPage
	{
        public EmployerCreateJobPage()
        {
            InitializeComponent();
        }

        private void OnAddJobClick(object sender, EventArgs e)
        {
            var job = (EmployerJobViewModel)BindingContext;
            job.Employer = Mapper.Map<EmployerViewModel>(App.User);
            EmployerJobsService.Add(Mapper.Map<EmployerJobModel>(job));
            Navigation.PopAsync();
        }
    }
}