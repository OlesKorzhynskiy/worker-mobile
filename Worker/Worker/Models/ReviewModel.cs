using System;

namespace Worker.Models
{
    public class ReviewModel
    {
        public UserModel Reviewer { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}