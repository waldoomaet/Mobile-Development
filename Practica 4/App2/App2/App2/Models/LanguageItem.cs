using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class LanguageItem
    {
        public string ImageSource{ get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public LanguageItem(string imageSource, string title, string subtitle)
        {
            this.ImageSource = imageSource;
            this.Title = title;
            this.Subtitle = subtitle;
        }
    }
}
