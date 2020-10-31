using neKot_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{
    class AuthViewModel
    {
        public Command OpenRegPageCommand{ get;}
        public AuthViewModel()
        {
            OpenRegPageCommand = new Command(async() => await ExecuteOpenRegPageCommand());
        }
        public async Task ExecuteOpenRegPageCommand()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}
