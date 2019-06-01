using System;

namespace Worker.Models
{
    public class Review
    {
        public User Reviewer { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}