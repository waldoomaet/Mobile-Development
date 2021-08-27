using App1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public string UserEntry { get; set; }
        public string PasswordEntry { get; set; }

        // Just fooling around with the INotifyPropertyChanged
        public Color ButtonColor { get; set; } = Color.Blue;
        public ICommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {
            LoginCommand = new Command(ValidateInputs);
        }

        private async void ValidateInputs()
        {
            if (String.IsNullOrEmpty(this.UserEntry) && String.IsNullOrEmpty(this.PasswordEntry))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Ambos campos deben estar llenos", "OK");
            }
            else if (String.IsNullOrEmpty(this.PasswordEntry))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "El campo de password no puede estar vacio", "OK");
            }
            else if (String.IsNullOrEmpty(this.UserEntry))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "El campo de user no puede estar vacio", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Bienvenido", $"Hola {this.UserEntry}", "OK");
                this.UserEntry = "";
                this.PasswordEntry = "";
                await App.Current.MainPage.Navigation.PushAsync(new FirstPage());
            }
            var rng = new Random();
            this.ButtonColor = new Color(rng.NextDouble(), rng.NextDouble(), rng.NextDouble());
        }
    }
}
