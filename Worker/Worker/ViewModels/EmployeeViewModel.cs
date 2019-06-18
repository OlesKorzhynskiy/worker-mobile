using System.Collections.ObjectModel;
using System.Windows.Input;
using Worker.Enums;
using Worker.Services;

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
                JobTypesListHeight = JobTypes.Count * 30;
                OnPropertyChanged();
            }
        }

        private int _jobTypesListHeight;
        public int JobTypesListHeight
        {
            get => _jobTypesListHeight;
            set
            {
                _jobTypesListHeight = value;
                OnPropertyChanged();
            }
        }
    }
}