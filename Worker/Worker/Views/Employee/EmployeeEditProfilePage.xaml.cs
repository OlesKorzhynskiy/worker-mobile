using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Interfaces;
using Worker.Models;
using Worker.Services;
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

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnAddJobTypes;
            AddJobTypeImage.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void OnSaveProfile(object sender, EventArgs e)
        {
            var userViewModel = (EmployeeViewModel)BindingContext;
            App.User = Mapper.Map<EmployeeModel>(userViewModel);
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
                var userViewModel = (EmployeeViewModel)BindingContext;
                userViewModel.Photo = ImageSource.FromStream(() => stream);
            }

            button.IsEnabled = true;
        }

        private void OnAddJobTypes(object sender, EventArgs e)
        {
            var userViewModel = (EmployeeViewModel)BindingContext;
            var jobTypes = Mapper.Map<ObservableCollection<JobTypeViewModel>>(JobTypesService.GetAll());
            foreach (var jobType in jobTypes)
            {
                if (userViewModel.JobTypes.Select(type => type.Id).Contains(jobType.Id))
                {
                    jobType.IsChecked = true;
                }
            }

            var addJobTypePage = new AddJobTypesPage() {BindingContext = jobTypes};
            addJobTypePage.OnAddJobTypes += OnAddedJobTypes;
            Navigation.PushModalAsync(addJobTypePage);
        }

        private void OnAddedJobTypes(ObservableCollection<JobTypeViewModel> jobTypes)
        {
            var userViewModel = (EmployeeViewModel)BindingContext;
            userViewModel.JobTypes.Clear();
            foreach (var jobType in jobTypes)
            {
                userViewModel.JobTypes.Add(jobType);
            }
            userViewModel.JobTypesListHeight = userViewModel.JobTypes.Count * 20;
        }
    }
}