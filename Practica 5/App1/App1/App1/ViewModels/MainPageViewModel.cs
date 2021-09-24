using App1.Models;
using App1.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class MainPageViewModel:INotifyPropertyChanged
    {
        public User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private AlertService _alert;

        public ICommand SignUpCommand { get; set; }
        public MainPageViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
            _alert = new AlertService();
        }
        private async void OnSignUp()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var result = await RestService.For<ISignUpApiService>("http://192.168.68.139:45455/api").Test();
            }
            else
            {
                await _alert.Alert("Error", "Sin conexión a Internet", "Ok");
            }
        }
    }
}
