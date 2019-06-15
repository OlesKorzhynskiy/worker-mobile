using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Models;
using Worker.Services;
using Worker.ViewModels;
using Worker.Views.Employer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Authentication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();

            SignInLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(OnSignIn)
            });

            TypePicker.SelectedIndex = 0;
        }

        private async void OnSignUp(object sender, EventArgs e)
        {
            var user = (UserModel)BindingContext;
            if (String.IsNullOrEmpty(user.Email))
            {
                ShowError("Вкажіть емейл");
                return;
            }
            if (String.IsNullOrEmpty(user.Password))
            {
                ShowError("Вкажіть пароль");
                return;
            }
            if (TypePicker.Items[TypePicker.SelectedIndex] == "Employer")
            {
                var employer = Mapper.Map<EmployerModel>(user);
                App.User = employer;
            }
            else
            {
                var employee = Mapper.Map<EmployeeModel>(user);
                App.User = employee;
            }

            App.Current.MainPage = new NavigationPage(new MainPage(true) { Title = "Редагувати" });
        }

        public void ShowError(string text)
        {
            ErrorLabel.IsVisible = true;
            ErrorLabel.Text = text;
        }

        private void OnSignIn()
        {
            var user = new UserModel();
            App.Current.MainPage = new SignInPage() { BindingContext = user };
        }
    }
}