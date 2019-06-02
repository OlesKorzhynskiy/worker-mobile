using Worker.Enums;

namespace Worker.ViewModels
{
    public class JobUserViewModel : BaseViewModel
    {
        private EmployeeViewModel _employee;
        public EmployeeViewModel Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private StatusEnum _status;
        public StatusEnum Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    }
}