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

namespace Worker.Views.Employee
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployeeEditProfilePage : ContentPage
	{
		public EmployeeEditProfilePage ()
		{
			InitializeComponent ();
		}

        private void OnSaveProfile(object sender, EventArgs e)
        {
            var userViewModel = (EmployeeViewModel)BindingContext;
            App.User = Mapper.Map<EmployeeModel>(userViewModel);
            Navigation.PopAsync();
        }
    }
}