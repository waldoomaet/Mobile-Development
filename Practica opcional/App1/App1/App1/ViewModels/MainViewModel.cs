using App1.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public ObservableCollection<MusicViewItem> MusicItems { get; set; }
        public MusicViewItem SelectedMusicItem { get; set; }
        public ICommand ItemSelectCommand { get; set; }
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            ItemSelectCommand = new DelegateCommand<MusicViewItem>(async (MusicViewItem musicItem) => 
            {
                await NavigationService.NavigateAsync($"{Constants.Navigation.Detail}", musicItem.ToNavigationParameters()); 
            });
            MusicItems = new ObservableCollection<MusicViewItem>()
            {
                new MusicViewItem() {ImagePath = "relax1", Title="Hola", Duration="3 min"},
                new MusicViewItem() {ImagePath = "relax2", Title="Hola", Duration="4 min"},
                new MusicViewItem() {ImagePath = "relax3", Title="Hola", Duration="5 min"},
                new MusicViewItem() {ImagePath = "relax1", Title="Hola", Duration="6 min"},
                new MusicViewItem() {ImagePath = "relax2", Title="Hola", Duration="7 min"},
                new MusicViewItem() {ImagePath = "relax3", Title="Hola", Duration="8 min"}
            };
        }
    }
}
