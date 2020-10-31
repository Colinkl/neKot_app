using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using neKot_app.Views;
using neKot_app.Models;

namespace neKot_app.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        private EventModel _selectedItem;
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommand {get; }
        public ObservableCollection<EventModel> News { get; set; }
        public Command<EventModel> ItemTapped { get; }

        
        public EventsViewModel()
        {
            
            Title = "News";
            News = new ObservableCollection<EventModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<EventModel>(OnItemSelected);
            AppearItemsCommand = new Command(async() => await ExecuteAppearItemsCommand());
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        public EventModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(EventModel news)
        {
            if (news == null)
                return;
            await OpenBrowser(news.Link);
                // This will push the ItemDetailPage onto the navigation stack           
        }
        private async Task ExecuteLoadItemsCommand()
        {
            //await Shell.Current.GoToAsync("//LoginPage");
            IsBusy = true;

            try
            {
                News.Clear();
                var item = new EventModel {Title = "Cats are the best!", 
                                           Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg", 
                                           Date_start =  DateTime.Now, 
                                           Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data" };
               
                News.Add(item);
                
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
        
        public async Task OpenBrowser(string uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
        private async Task ExecuteAppearItemsCommand()
        {
            //await Shell.Current.GoToAsync("//LoginPage");
         
            try
            {
                News.Clear();
                var item = new EventModel {Title = "Cats are the best!", 
                                           Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg", 
                                           Date_start =  DateTime.Now, 
                                           Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data" };
               
                News.Add(item);
                
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
