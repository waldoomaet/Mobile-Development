using App1.Models;
using Plugin.LocalNotification;
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

        private async void SendEmail()
        {
            Email.ImageSource = "profile_black.png";
            Email.Date = DateTime.Now;
            SetEmail(Email, EventArgs.Empty);
            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = Email.Title,
                Description = Email.Description,
                ReturningData = "Dummy data", // Returning data when tapped on notification.
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(3)
                }
            };
            await NotificationCenter.Current.Show(notification);
            await SendActualEmail();
            await App.Current.MainPage.DisplayAlert("Enviado", "Email enviado satisfactoriamente!", "OK");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx) { }
            catch (PermissionException pEx) { }
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

        private async Task SendActualEmail()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = Email.Title,
                    Body = Email.Description,
                    To = new List<string>() { Email.From }
                };
                await Xamarin.Essentials.Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx) {}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}