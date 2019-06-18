using System;
using System.Collections.Generic;
using Worker.Enums;

namespace Worker.Models
{
    public class EmployerJobModel
    {
        public EmployerJobModel()
        {
            Employees = new List<JobUserModel>();
            IsLookingForNewEmployees = true;
            IsClosed = false;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }

        public JobTypeModel JobType { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }

        public EmployerModel Employer { get; set; }

        public bool IsLookingForNewEmployees { get; set; }

        public bool IsClosed { get; set; }

        public List<JobUserModel> Employees { get; set; }
    }
}