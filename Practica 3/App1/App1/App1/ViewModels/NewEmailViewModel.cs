using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class NewEmailViewModel: INotifyPropertyChanged
    {
        public Models.Email Email { get; set; } = new Models.Email();
        public delegate void SetEmailHandler (object source, EventArgs args);
        public event SetEmailHandler SetEmail;
        public event PropertyChangedEventHandler PropertyChanged;

        public string PhotoPath { get; set; }

        public bool PhotoAttached { get; set; } = false;
        public ICommand SendCommand { get; set; }
        public ICommand AttachCommand { get; set; }

        public NewEmailViewModel() 
        {
            SendCommand = new Command(SendEmail);
            AttachCommand = new Command(TakePhotoAsync);
        }

        public async void SendEmail()
        {
            Email.ImageSource = "profile.png";
            Email.Date = DateTime.Now;
            await App.Current.MainPage.DisplayAlert("Enviado", "Email enviado satisfactoriamente!", "OK");
            SetEmail(Email, EventArgs.Empty);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async void TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                Email.AttachedPhotoPath = null;
                return;
            }
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            Email.AttachedPhotoPath = newFile;
            PhotoPath = newFile;
            PhotoAttached = true;
        }
    }
}