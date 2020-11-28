using neKot_app.Models;
using neKot_app.Services;
using neKot_app.Views;
using neKot_app.Views.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace neKot_app.ViewModels.Profile
{
    public class TutorSelectViewModel : BaseViewModel
    {

        private TutorService tutorService;
        public Command BackCommand { get;  }
        private int id;
        public string Avatar { get => Tutor.avatar; }
        public string MyProperty { get; set; }
        Command GetTutorCommand{get; }
        async Task GetTutor(int id)
        {
            try
            {
                if (CurrentUser == null)
                {
                    await Shell.Current.GoToAsync("///LoginPage");
                    return;
                }
                TutorModel tutors = await tutorService.GetTutor(id);
                Tutor = tutors;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
           
            
        }
        private TutorModel tutor;
        public TutorModel Tutor
        {
            get => tutor;
            set
            {
                if (value == tutor)
                {
                    return;
                }
                tutor = value;
                OnPropertyChanged(nameof(Tutor));
            }
        }
        public Command OpenTutorProfileCommand {get;}
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
                string fullname = Tutor.first_name + " " + Tutor.last_name;                
                return fullname;
            }           
        }
        public TutorSelectViewModel()
        {
            OpenTutorProfileCommand = new Command(async() => await ExecuteOpenAchivementsCommand());
            RegisterAgainCommand = new Command(async () => await ExecuteRegisterAgainCommand());
            CheckAuthCommand = new Command(async() => await ExecuteCheckAuthCommand());
            CheckAuthCommand.Execute(0);
            OpenTutorCommand = new Command(async() => await ExecuteOpenTutorCommand());
            BackCommand = new Command(async() => await ExecuteBackCommand());
            tutorService = new TutorService(DependencyService.Get<HttpClient>());
            
            

        }
        private async Task ExecuteBackCommand()
        {
            await Shell.Current.GoToAsync("///Profile");
        }
        private async Task ExecuteOpenAchivementsCommand()
        {
             await GetTutor(0);
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
        private async Task ExecuteOpenTutorCommand()
        {
             await Shell.Current.GoToAsync(nameof(TutorsListPage));
        }
    }
    
}
