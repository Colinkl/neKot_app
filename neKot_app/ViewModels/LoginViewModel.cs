using neKot_app.Models;
using neKot_app.Services;
using neKot_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        User user;
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            DependencyService.Get<UserSaveService>().SaveUser(user);
            await Shell.Current.GoToAsync($"..");
        }
    }
}
