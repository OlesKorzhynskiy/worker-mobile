using System.Windows.Input;
using Worker.Enums;
using Worker.Services;

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

        public bool IsWaitingForEmployerConfirmation => Status == StatusEnum.WaitingForEmployerConfirmation;
        public bool IsWaitingForEmployeeConfirmation => Status == StatusEnum.WaitingForEmployeeConfirmation;
        public bool IsDone => Status == StatusEnum.Done;
        public bool IsInProgress => Status == StatusEnum.InProgress;
    }
}