using System.Collections.Generic;

namespace Worker.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        
        public List<Review> ReceivedReviews { get; set; }
    }
}