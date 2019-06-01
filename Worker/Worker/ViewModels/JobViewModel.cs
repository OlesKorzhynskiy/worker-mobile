using System;
using Worker.Enums;
using Worker.Models;

namespace Worker.ViewModels
{
    public class JobViewModel : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private int _rate;
        public int Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                OnPropertyChanged();
            }
        }

        private JobTypeModel _jobType;
        public JobTypeModel JobType
        {
            get => _jobType;
            set
            {
                _jobType = value;
                OnPropertyChanged();
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                _duration = value;
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

        private EmployerViewModel _employer;
        public EmployerViewModel Employer
        {
            get => _employer;
            set
            {
                _employer = value;
                OnPropertyChanged();
            }
        }

        // statuses
        public bool IsNew => Status == StatusEnum.WaitingForEmployee;
        public bool IsWaitingForEmployerConfirmation => Status == StatusEnum.WaitingForEmployerConfirmation;
        public bool IsWaitingForEmployeeConfirmation => Status == StatusEnum.WaitingForEmployeeConfirmation;
        public bool IsRejectedByEmployer => Status == StatusEnum.RejectedByEmployer;
        public bool IsRejectedByEmployee => Status == StatusEnum.RejectedByEmployee;
        public bool IsInProgress => Status == StatusEnum.InProgress;
        public bool IsDone => Status == StatusEnum.Done;

    }
}