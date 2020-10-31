using neKot_app.Models;
using neKot_app.Services;
using neKot_app.Views.Profile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace neKot_app.ViewModels.Profile
{
   public class TutorListViewModel : BaseViewModel
    {
        private TutorModel _selectedItem;
        public Command<TutorModel> ItemTapped{get; set;}
        private TutorService tutorService;
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommamd { get; }
        public Command BackCommand { get;  }
        public ObservableCollection<TutorModel> TutorsList { get; set; }
        


        public TutorListViewModel()
        {
            Title = "Тьюторы";
            TutorsList = new ObservableCollection<TutorModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AppearItemsCommamd = new Command(async() => await ExecuteAppearItemsCommand());
            BackCommand = new Command(async() => await ExecuteBackCommand());
            tutorService = new TutorService(DependencyService.Get<HttpClient>());
            ItemTapped = new Command<TutorModel>(OnItemSelected);
        }
         async void OnItemSelected(TutorModel item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack            
            CurrentUser.TutorID = item.id;
            //await Shell.Current.GoToAsync(nameof(TutorSelectPage));
            //await Shell.Current.GoToAsync($"{nameof(TutorSelectPage)}?{nameof(TutorSelectViewModel.Id)}={item.id}");            
            
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        public TutorModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
                
       

        private async Task ExecuteLoadItemsCommand()
        {
            //TutorsList.Clear();
            //TutorsList.Add(new TutorModel(){ avatar = "https://sun9-55.userapi.com/c639718/v639718251/3fb5/XQ8P9uRMO-E.jpg", 
            //                                 first_name = "Никита", 
            //                                 last_name = "Камышников", 
            //                                 description = "Великий фотограф 2020", 
            //                                 email = "caaa",
            //                                 vk_link = "/meow",
            //                                 telegram_link = "@meow",
            //                                 whatsapp_link = "88005553535"});
            //IsBusy = false;
            IsBusy = true;
            TutorsList.Clear();
            try
            {
                await UpdateAchievements();
            }
            catch (Exception ex)
            {
                TutorsList.Add(new TutorModel() {first_name ="Ошибка доступа к БД"});
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteBackCommand()
        {
            await Shell.Current.GoToAsync("///Profile");
        }

        
        private async Task ExecuteAppearItemsCommand()
        {
            //TutorsList.Clear();
            //TutorsList.Add(new TutorModel(){ avatar = "", first_name = "Cat", last_name = "meow", description = "a", email = "caaa"});
            //IsBusy = false;
            
            
                    try
                    {
                        await UpdateAchievements();
                    }
                    catch (Exception ex)
                    {
                        TutorsList.Add(new TutorModel() {first_name ="Ошибка доступа к БД"});
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
            List<TutorModel> tutors = await tutorService.GetTutors(1);
            
            foreach (var item in tutors)
            {
                TutorsList.Add(item);
            }
        }
    }
    
}
