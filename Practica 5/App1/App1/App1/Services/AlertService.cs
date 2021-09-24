using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class AlertService : IAlertService
    {
        public async Task Alert(string title, string message, string cancel) => await App.Current.MainPage.DisplayAlert(title, message, cancel);
    }
}
