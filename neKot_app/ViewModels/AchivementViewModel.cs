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
        public Command AppearItemsCommamd {get; }
        public ObservableCollection<Achivement> Achivements { get; set; }

        private AchivementsSearch achivementsSearch;
        private User currentUser; // Need to make it static on aplication
        public AchivementViewModel()
        {
            Title = "Achivements";
            Achivements = new ObservableCollection<Achivement>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            achivementsSearch = new AchivementsSearch(HttpClient);
            currentUser = new User() { FirstName = "Алексей", LastName = "Бакланов" };
            AppearItemsCommamd = new Command(async() => await ExecuteAppearItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            Achivements.Clear();
            try
            {
                
                List<Achivement> achivements = await achivementsSearch.GetAchivementsByName(currentUser);
                //Achivements = new ObservableCollection<Achivement>(achivements);
                foreach (var item in achivements)
                {
                    Achivements.Add(item);
                }
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
        public void OnAppearing()
        {
            IsBusy = true;            
        }
        private async Task ExecuteAppearItemsCommand()
        {
            
            Achivements.Clear();
            try
            {
                
                List<Achivement> achivements = await achivementsSearch.GetAchivementsByName(currentUser);
                //Achivements = new ObservableCollection<Achivement>(achivements);
                foreach (var item in achivements)
                {
                    Achivements.Add(item);
                }
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
    }
}
