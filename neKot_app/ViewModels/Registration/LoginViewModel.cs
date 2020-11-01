using neKot_app.Models;
using neKot_app.Services;
using neKot_app.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{

    public class LoginViewModel : BaseViewModel
    {
        private AchivementsSearch FirstachivementsSearch;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone {get; set;}
        public string Password {get; set;}
        public bool Checkbox { get; set; }

        private string errMessage;
        public string ErrMessage
        {
            get => errMessage;
            set
            {
                if (value == errMessage)
                {
                    return;
                }
                errMessage = value;
                OnPropertyChanged(nameof(ErrMessage));
            }
        }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            FirstachivementsSearch = new AchivementsSearch(DependencyService.Get<HttpClient>());
        }

        private async void OnLoginClicked(object obj)
        {
            ErrMessage = "";
            if (!Checkbox)
            {
                ErrMessage = "Неободимо дать согласие на передачу и использование данных";
                return;
            }
            var tempUser = new User(){ FirstName = this.FirstName, LastName = this.LastName } ;
            var tempList = await FirstachivementsSearch.GetAchivementsByName(tempUser);
            if (tempList.Where(u => u.ChildName.ToLower() == (tempUser.LastName + " " + tempUser.FirstName).ToLower()).ToList().Count == 0)
            {
                ErrMessage = "Пользователь не найден" ;
                return;
            }
            DependencyService.Get<UserSaveService>().SaveUser(tempUser);
            await Shell.Current.GoToAsync("///Profile");
        }
    }
}
