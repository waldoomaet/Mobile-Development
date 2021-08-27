using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Models
{
    class MenuOption
    {
        public string ImageSrc { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public MenuOption(string imageSrc, string title, string subtitle)
        {
            this.ImageSrc = imageSrc;
            this.Title = title;
            this.Subtitle = subtitle;
        }
    }
}
