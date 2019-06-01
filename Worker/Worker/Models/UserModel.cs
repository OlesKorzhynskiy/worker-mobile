using System;
using System.Collections.Generic;

namespace Worker.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int AverageRating { get; set; }
        
        public List<ReviewModel> ReceivedReviews { get; set; }
    }
}