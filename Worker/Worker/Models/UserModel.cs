using System;
using System.Collections.Generic;

namespace Worker.Models
{
    public class UserModel
    {
        public UserModel()
        {
            ReceivedReviews = new List<ReviewModel>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int AverageRating { get; set; }
        public string AboutMe { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public List<ReviewModel> ReceivedReviews { get; set; }
    }
}