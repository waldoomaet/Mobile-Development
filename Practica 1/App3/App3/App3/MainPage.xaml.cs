using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnLoginClicked(object sender, EventArgs args)
        {
            if (String.IsNullOrEmpty(userEntry.Text) && String.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Alerta", "Ambos campos deben estar llenos", "OK");
            }
            else if (String.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Alerta", "El campo de password no puede estar vacio", "OK");
            }
            else if (String.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Alerta", "El campo de user no puede estar vacio", "OK");
            }
            else
            {
                await DisplayAlert("Bienvenido", $"Hola {userEntry.Text}", "OK");
            }
        }
    }
}
