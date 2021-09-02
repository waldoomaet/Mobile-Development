using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Email
    {
        public string ImageSource { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string AttachedPhotoPath { get; set; }
        public string From { get; set; }

        public Email() { }

        public Email(string imageSource, string title, string description, DateTime date, string from)
        {
            this.ImageSource = imageSource;
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.From = from;
        }
    }
}
