using neKot_app.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace neKot_app.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new neKot_app.ViewModels.AboutViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.AppearItemsCommand.Execute(0);
        }
    }
}