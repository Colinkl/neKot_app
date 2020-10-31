using neKot_app.Models;
using neKot_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command OpenAchivementsCommand {get;}
        public Command RegisterAgainCommand { get;  }
        public Command CheckAuthCommand {get;}
        public Command OpenTutorCommand {get;}
     

        string profileImage = "https://i.pinimg.com/736x/27/aa/5a/27aa5a2ff02558ef7d099355ed79b022.jpg";
        public string ProfileImage
        {
            get => profileImage;
            set
            {
                if (value == profileImage)
                {
                    return;
                }
                profileImage = value;
                OnPropertyChanged(nameof(ProfileImage));
            }
        }
        public string FullName
        {
            get
            {
                string fullname = CurrentUser?.FirstName + " " + CurrentUser?.LastName;                
                return fullname;
            }           
        }
        public ProfileViewModel()
        {
            OpenAchivementsCommand = new Command(async() => await ExecuteOpenAchivementsCommand());
            RegisterAgainCommand = new Command(async () => await ExecuteRegisterAgainCommand());
            CheckAuthCommand = new Command(async() => await ExecuteCheckAuthCommand());
            CheckAuthCommand.Execute(0);
            OpenTutorCommand = new Command();
        }
        private async Task ExecuteOpenAchivementsCommand()
        {
             await Shell.Current.GoToAsync(nameof(AchivementPage));
        }

        private async Task ExecuteRegisterAgainCommand()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
        private async Task ExecuteCheckAuthCommand()
        {
            if (CurrentUser == null)
            {
                await Shell.Current.GoToAsync(nameof(AuthPage));
                return;
            }
        }
    }
}
