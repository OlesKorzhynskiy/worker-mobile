using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using Worker.Enums;
using Worker.Models;
using Worker.Services;

namespace Worker.ViewModels
{
    public class EmployerJobViewModel : BaseViewModel
    {
        public EmployerJobViewModel()
        {
            JobTypes = Mapper.Map<ObservableCollection<JobTypeViewModel>>(JobTypesService.GetAll());
            JobType = JobTypes.FirstOrDefault();
            Employees = new List<JobUserViewModel>();
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

        public bool IsDone => Employees.Count != 0 && Employees.All(jobEmployee => jobEmployee.Status == StatusEnum.Done);

        public bool IsActive => Employees.Count == 0 || Employees.Exists(jobEmployee => jobEmployee.Status != StatusEnum.Done);
    }
}