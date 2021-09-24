using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace App1.ViewModels
{
    class MainPageViewModel:INotifyPropertyChanged
    {
        public User User { get; set; }
        public string test { get; set; } = "Prueba";
        public event PropertyChangedEventHandler PropertyChanged;

        private AlertService _alertService;
        private SignUpApiService _signUpService;

        public ICommand SignUpCommand { get; set; }
        public MainPageViewModel()
        {
            User = new User();
            SignUpCommand = new Command(OnSignUp);
            _alertService = new AlertService();
            _signUpService = new SignUpApiService();
        }
        private async void OnSignUp()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await _signUpService.Create(User);
                if(response.Status == "success")
                {
                    User returnedUser = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(response.Data));
                    await _alertService.Alert("Success!", $"{returnedUser.FullName} tu usuario fue creado satisfactoriamente!", "Ok");
                }
                else if(response.Status == "fail")
                {
                    var returnedData = JsonSerializer.Deserialize<Dictionary<string,string>>(JsonSerializer.Serialize(response.Data));
                    await _alertService.Alert("Error", $"{returnedData.First().Value}", "Ok");
                }
                else
                {
                    await _alertService.Alert("Error", $"Algo ocurrio: {response.ErrorMessage}", "Ok");
                }
            }
            else
            {
                await _alertService.Alert("Error", "Sin conexión a Internet", "Ok");
            }
        }
    }
}
