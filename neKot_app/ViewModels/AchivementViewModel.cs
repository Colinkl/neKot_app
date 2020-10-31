using neKot_app.Models;
using neKot_app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{
     public class  AchivementViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommamd { get; }
        public Command BackCommand { get;  }
        public ObservableCollection<Achivement> Achivements { get; set; }

        private AchivementsSearch achivementsSearch;
        public AchivementViewModel()
        {
            Title = "Achivements";
            Achivements = new ObservableCollection<Achivement>();
            achivementsSearch = new AchivementsSearch(HttpClient);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AppearItemsCommamd = new Command(async() => await ExecuteAppearItemsCommand());
            BackCommand = new Command(async() => await ExecuteBackCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            Achivements.Clear();
            try
            {
                await UpdateAchievements();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteBackCommand()
        {
            await Shell.Current.GoToAsync("..");
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
        private async Task ExecuteAppearItemsCommand()
        {   
            Achivements.Clear();
            try
            {
                await UpdateAchievements();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task UpdateAchievements()
        {
             if (CurrentUser == null)
            {
                await Shell.Current.GoToAsync("///LoginPage");
                return;
            }
            List<Achivement> achivements = await achivementsSearch.GetAchivementsByName(CurrentUser);
            foreach (var item in achivements)
            {
                Achivements.Add(item);
            }
        }
    }
}
