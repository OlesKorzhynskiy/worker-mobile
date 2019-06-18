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
	public partial class EmployeeSettingsPage : ContentPage
	{
		public EmployeeSettingsPage ()
		{
			InitializeComponent ();

            BindingContext = Mapper.Map<SettingsViewModel>(App.User);
        }

        protected override void OnAppearing()
        {
            BindingContext = Mapper.Map<SettingsViewModel>(App.User);
        }
    }
}