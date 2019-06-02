using System;
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

        private string _photo;
        public string Photo
        {
            get => _photo;
            set
            {
                _photo = value;
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

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }        

        private string _averageRating;
        public string AverageRating
        {
            get => _averageRating;
            set
            {
                _averageRating = value;
                OnPropertyChanged();
            }
        }

        private string _aboutMe;
        public string AboutMe
        {
            get => _aboutMe;
            set
            {
                _aboutMe = value;
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

        // additional properties
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                // Go back to the year the person was born in case of a leap year
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public string UserName => FirstName + " " + LastName;

        public string CityAndAge => City + ", " + Age;
    }
}