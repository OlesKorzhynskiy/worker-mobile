using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Models;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerEditProfilePage : ContentPage
	{
		public EmployerEditProfilePage ()
		{
			InitializeComponent ();
		}

        private void OnSaveProfile(object sender, EventArgs e)
        {
            var userViewModel = (EmployerViewModel)BindingContext;
            App.User = Mapper.Map<EmployerModel>(userViewModel);
            Navigation.PopAsync();
        }
    }
}