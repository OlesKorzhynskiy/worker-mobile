using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Models;
using Worker.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();

            SignUpLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(OnSignUp)
            });
        }

        private void OnSignIn(object sender, EventArgs e)
        {
            var user = UsersService.Get(Email.Text);
            if (user != null && user.Password == Password.Text)
            {
                App.User = user;
                App.Current.MainPage = new MainPage();
            }
            else
            {
                ErrorLabel.Text = "Email or password is incorrect";
            }
        }

        private void OnSignUp()
        {
            var user = new UserModel();
            App.Current.MainPage = new SignUpPage() { BindingContext = user };
        }
    }
}