using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class TabBarOption
    {
        public TabBarOption(string imageSource, string title)
        {
            ImageSource = imageSource;
            Title = title;
        }
        public string ImageSource { get; }
        public string Title { get; }
    }
}
