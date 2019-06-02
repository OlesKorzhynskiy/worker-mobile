using Worker.Enums;

namespace Worker.Models
{
    public class JobUserModel
    {
        public EmployeeModel Employee { get; set; }
        public StatusEnum Status { get; set; }
    }
}