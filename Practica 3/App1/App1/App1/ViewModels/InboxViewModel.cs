using App1.Models;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace App1.ViewModels
{
    public class InboxViewModel: INotifyPropertyChanged
    {
        private Models.Email _selectedEmail;
        public Models.Email SelectedEmail
        {
            get
            {
                return _selectedEmail;
            }
            set
            {
                _selectedEmail = value;
                ShowEmailCommand.Execute(value);
            }
        }
        public ObservableCollection<Models.Email> Emails { get; set; } = new ObservableCollection<Models.Email>();

        public bool HasEmails { get; set; }

        public bool HasNoEmails { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DeleteEmailCommand { get; set; }
        public ICommand ShowEmailCommand { get; set; }

        public ICommand AddEmailCommand { get; set; }

        public InboxViewModel()
        {
            DeleteEmailCommand = new Command<Models.Email>(DeleteEmail);
            AddEmailCommand = new Command(AddEmail);
            ShowEmailCommand = new Command<Models.Email>(ShowEmail);
            if (Preferences.ContainsKey("json_data"))
            {
                Emails = JsonConvert.DeserializeObject<ObservableCollection<Models.Email>>(Preferences.Get("json_data", "default"));
            }
            else
            {
                Emails = new ObservableCollection<Models.Email>();
                Preferences.Set("json_data", JsonConvert.SerializeObject(Emails));
            }
            
            if(Emails.Count > 0)
            {
                HasEmails = true;
            }
            else
            {
                HasEmails = false;
            }
            HasNoEmails = !HasEmails;
        }

        private void DeleteEmail(Models.Email email)
        {
            Emails.Remove(email);
            Preferences.Set("json_data", JsonConvert.SerializeObject(Emails));
            if (Emails.Count > 0)
            {
                HasEmails = true;
            }
            else
            {
                HasEmails = false;
            }
            HasNoEmails = !HasEmails;
        }

        private async void ShowEmail(Models.Email email) => await App.Current.MainPage.Navigation.PushAsync(new EmailDetailPage(email));
        private async void AddEmail() => await App.Current.MainPage.Navigation.PushAsync(new NewEmailPage(Emails));
    }
}
