using System.Collections.ObjectModel;

namespace Worker.ViewModels
{
    public class EmployeeViewModel : UserViewModel
    {
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

        private ObservableCollection<JobTypeViewModel> _jobTypes;
        public ObservableCollection<JobTypeViewModel> JobTypes
        {
            get => _jobTypes;
            set
            {
                _jobTypes = value;
                OnPropertyChanged();
            }
        }
    }
}