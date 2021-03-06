using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using neKot_app.Services;
using neKot_app.Views;
using System.Net.Http;

namespace neKot_app
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<HttpClient>();
            DependencyService.Register<UserSaveService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
