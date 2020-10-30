using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using neKot_app.Services;
using neKot_app.Views;

namespace neKot_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //Shell.Current.GoToAsync("//LoginPage");
            
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
