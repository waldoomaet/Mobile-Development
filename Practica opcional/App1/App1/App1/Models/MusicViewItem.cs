using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class MusicViewItem : NavigationParametersManager
    {
        public MusicViewItem() { }
        public MusicViewItem(INavigationParameters navigationParameters) : base(navigationParameters) { }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
    }
}
