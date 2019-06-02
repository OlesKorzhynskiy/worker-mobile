using System.Windows.Input;
using Worker.Models;
using Xamarin.Forms;

namespace Worker.ViewModels
{
    public class EmployeeSettingsViewModel : BaseViewModel
    {
        public EmployeeSettingsViewModel()
        {
            UpdateEmailCommand = new Command(UpdateEmail);
            UpdatePhoneCommand = new Command(UpdatePhone);
            UpdatePasswordCommand = new Command(UpdatePassword);
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                var user = (EmployeeModel)App.User;
                if (user.IsVisible != value)
                {
                    user.IsVisible = value;
                }
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _oldPassword;
        public string OldPassword
        {
            get => _oldPassword;
            set
            {
                _oldPassword = value;
                OnPropertyChanged();
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        private string _confirmNewPassword;
        public string ConfirmNewPassword
        {
            get => _confirmNewPassword;
            set
            {
                _confirmNewPassword = value;
                OnPropertyChanged();
            }
        }

        // commands
        public ICommand UpdateEmailCommand { get; }
        private void UpdateEmail()
        {
            App.User.Email = Email;
        }

        public ICommand UpdatePhoneCommand { get; }
        private void UpdatePhone()
        {
            App.User.Phone = Phone;
        }

        public ICommand UpdatePasswordCommand { get; }
        private void UpdatePassword()
        {
            if (App.User.Password == OldPassword && NewPassword == ConfirmNewPassword)
            {
                App.User.Password = NewPassword;
            }
        }
    }
}