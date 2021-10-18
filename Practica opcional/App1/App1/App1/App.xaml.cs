using App1.ViewModels;
using App1.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{Constants.Navigation.Nav}/{Constants.Navigation.Main}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(Constants.Navigation.Main);
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.Navigation.Nav);
            containerRegistry.RegisterForNavigation<DetailPage, DetailViewModel>(Constants.Navigation.Detail);
        }
    }
}
