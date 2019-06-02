using System.Collections.ObjectModel;

namespace Worker.ViewModels
{
    public class EmployeeViewModel : UserViewModel
    {
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