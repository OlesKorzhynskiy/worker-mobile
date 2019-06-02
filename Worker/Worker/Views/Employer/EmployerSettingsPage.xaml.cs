using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerSettingsPage : ContentPage
	{
		public EmployerSettingsPage ()
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