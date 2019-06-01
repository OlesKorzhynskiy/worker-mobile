using System;
using System.Collections.Generic;
using System.Text;

namespace Worker.Models
{
    public class EmployeeModel : UserModel
    {
        public string AboutMe { get; set; }
        public List<JobTypeModel> JobTypes { get; set; }
    }
}
