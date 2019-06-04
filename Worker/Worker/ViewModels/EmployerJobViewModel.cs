using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Worker.Enums;
using Worker.Models;
using Worker.Services;
using Xamarin.Forms;

namespace Worker.ViewModels
{
    public class EmployerJobViewModel : BaseViewModel
    {
        public EmployerJobViewModel()
        {
            JobTypes = Mapper.Map<ObservableCollection<JobTypeViewModel>>(JobTypesService.GetAll());
            JobType = JobTypes.FirstOrDefault();
            Employees = new List<JobUserViewModel>();
            IsLookingForNewEmployees = true;
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

        private JobTypeViewModel _jobType;
        public JobTypeViewModel JobType
        {
            get => _jobType;
            set
            {
                _jobType = value;
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

        private bool _isLookingForNewEmployees;
        public bool IsLookingForNewEmployees
        {
            get => _isLookingForNewEmployees;
            set
            {
                _isLookingForNewEmployees = value;
                OnPropertyChanged();
                OnPropertyChanged("IsNotLookingForNewEmployees");
            }
        }

        private bool _isClosed;
        public bool IsClosed
        {
            get => _isClosed;
            set
            {
                _isClosed = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotLookingForNewEmployees => !IsLookingForNewEmployees;

        private List<JobUserViewModel> _employees;
        public List<JobUserViewModel> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public int AppliedNumber => Employees.Count;

        public int WaitingForAnswerNumber => Employees.Count(employee => employee.Status == StatusEnum.WaitingForEmployerConfirmation);

        public int WorkedOnNumber => Employees.Count(employee => employee.Status == StatusEnum.Done);

        public List<JobUserViewModel> AppliedEmployees => Employees.Where(employee =>
            employee.Status == StatusEnum.WaitingForEmployeeConfirmation ||
            employee.Status == StatusEnum.WaitingForEmployerConfirmation).ToList();

        public List<JobUserViewModel> AgreedEmployees => Employees.Where(employee =>
            employee.Status == StatusEnum.InProgress || employee.Status == StatusEnum.Done).ToList();

        public List<JobUserViewModel> WorkedOnEmployees => Employees.Where(employee =>
            employee.Status == StatusEnum.Done).ToList();

        public bool IsActive => !IsClosed;
    }
}