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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone {get; set;}
        public string Password {get; set;}
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            DependencyService.Get<UserSaveService>().SaveUser(new User() { FirstName = this.FirstName, LastName = this.LastName});
            await Shell.Current.GoToAsync("///Profile");
        }
    }
}
