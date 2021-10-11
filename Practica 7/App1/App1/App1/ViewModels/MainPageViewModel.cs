using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public string Orientation { get; set; }
        public string[] SomeList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            SomeList = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ".Split(' ');
            string orientation = DependencyService.Get<IDeviceOrientationService>().GetOrientation().ToString();
            Orientation = $"La orientacion de la pantalla es: {orientation}";
        }
    }
}
