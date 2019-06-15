using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Interfaces;
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
            App.User = Mapper.Map<EmployerModel>((EmployerViewModel)BindingContext);
            Navigation.PopAsync();
        }

        private async void OnUploadPhotoClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.IsEnabled = false;
            var picturePicker = DependencyService.Get<IPicturePicker>();
            Stream stream = await picturePicker.GetImageStreamAsync();

            if (stream != null)
            {
                var userViewModel = (EmployerViewModel)BindingContext;
                userViewModel.Photo = ImageSource.FromStream(() => stream);
            }

            button.IsEnabled = true;
        }
    }
}