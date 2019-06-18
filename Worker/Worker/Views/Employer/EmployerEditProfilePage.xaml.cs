using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Helpers;
using Worker.Interfaces;
using Worker.Models;
using Worker.Services;
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
            var user = UsersService.Add(Mapper.Map<EmployerModel>((EmployerViewModel)BindingContext));
            App.User = user;
            Navigation.PopAsync();
        }

        private async void OnUploadPhotoClick(object sender, EventArgs e)
        {
            var userViewModel = (EmployerViewModel)BindingContext;

            var button = (Button)sender;
            button.IsEnabled = false;
            var picturePicker = DependencyService.Get<IPicturePicker>();
            Stream stream = await picturePicker.GetImageStreamAsync();

            if (stream != null)
            {
                var bytes = ConverterHelper.ReadFully(stream);
                userViewModel.Photo = ImageSource.FromStream(() => new MemoryStream(bytes));
            }

            button.IsEnabled = true;
        }
    }
}