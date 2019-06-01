using System.Collections.ObjectModel;

namespace Worker.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
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

        private string _age;
        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ReviewViewModel> _receivedReviews;
        public ObservableCollection<ReviewViewModel> ReceivedReviews
        {
            get => _receivedReviews;
            set
            {
                _receivedReviews = value;
                OnPropertyChanged();
            }
        }
    }
}