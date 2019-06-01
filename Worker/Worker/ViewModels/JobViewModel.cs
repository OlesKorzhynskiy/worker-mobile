using System;
using System.Windows.Input;
using AutoMapper;
using Worker.Enums;
using Worker.Models;
using Worker.Services;
using Xamarin.Forms;

namespace Worker.ViewModels
{
    public class JobViewModel : BaseViewModel
    {
        public JobViewModel()
        {
            RemoveJobCommand = new Command(RemoveJob);
            ApplyJobCommand = new Command(ApplyJob);
            RejectJobCommand = new Command(RejectJob);
            AcceptJobCommand = new Command(AcceptJob);
            ReturnJobCommand = new Command(ReturnJob);
        }
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

        // Statuses
        public bool IsNew => Status == StatusEnum.WaitingForEmployee;
        public bool IsWaitingForEmployerConfirmation => Status == StatusEnum.WaitingForEmployerConfirmation;
        public bool IsWaitingForEmployeeConfirmation => Status == StatusEnum.WaitingForEmployeeConfirmation;
        public bool IsRejectedByEmployer => Status == StatusEnum.RejectedByEmployer;
        public bool IsRejectedByEmployee => Status == StatusEnum.RejectedByEmployee;
        public bool IsInProgress => Status == StatusEnum.InProgress;
        public bool IsDone => Status == StatusEnum.Done;
        public bool IsRemoved => Status == StatusEnum.Removed;

        // Commands
        public ICommand RemoveJobCommand { get; }
        private void RemoveJob()
        {
            JobsService.Remove(Id);
            Status = StatusEnum.Removed;
            UpdateView();
        }

        public ICommand ApplyJobCommand { get; }
        private void ApplyJob()
        {
            JobsService.Apply(Id);
            Status = StatusEnum.WaitingForEmployerConfirmation;
            UpdateView();
        }

        public ICommand RejectJobCommand { get; }
        private void RejectJob()
        {
            JobsService.RejectByEmployee(Id);
            Status = StatusEnum.RejectedByEmployee;
            UpdateView();
        }

        public ICommand AcceptJobCommand { get; }
        private void AcceptJob()
        {
            JobsService.AcceptByEmployee(Id);
            Status = StatusEnum.InProgress;
            UpdateView();
        }

        public ICommand ReturnJobCommand { get; }
        private void ReturnJob()
        {
            JobsService.Return(Id);
            Status = StatusEnum.WaitingForEmployee;
            UpdateView();
        }

        private void UpdateView()
        {
            OnPropertyChanged($"IsNew");
            OnPropertyChanged($"IsWaitingForEmployerConfirmation");
            OnPropertyChanged($"IsWaitingForEmployeeConfirmation");
            OnPropertyChanged($"IsRejectedByEmployer");
            OnPropertyChanged($"IsRejectedByEmployee");
            OnPropertyChanged($"IsInProgress");
            OnPropertyChanged($"IsDone");
            OnPropertyChanged($"IsRemoved");
        }
    }
}