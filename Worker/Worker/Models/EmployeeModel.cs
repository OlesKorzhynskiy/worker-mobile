using System;
using System.Collections.Generic;
using System.Text;

namespace Worker.Models
{
    public class EmployeeModel : UserModel
    {
        public EmployeeModel()
        {
            JobTypes = new List<JobTypeModel>();
        }

        public string AboutMe { get; set; }
        public List<JobTypeModel> JobTypes { get; set; }
        public bool IsVisible { get; set; }
    }
}
