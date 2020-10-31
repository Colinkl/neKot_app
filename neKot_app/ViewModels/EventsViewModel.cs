using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using neKot_app.Views;
using neKot_app.Models;
using neKot_app.Services;
using System.Net.Http;

namespace neKot_app.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        private EventModel _selectedItem;
        private EventService eventService;
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommand {get; }
        public ObservableCollection<EventModel> EventsCollection { get; set; }
        public Command<EventModel> ItemTapped { get; }

        
        public EventsViewModel()
        {
            Title = "Events";
            EventsCollection = new ObservableCollection<EventModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<EventModel>(OnItemSelected);
            AppearItemsCommand = new Command(async() => await ExecuteAppearItemsCommand());
            eventService = new EventService(DependencyService.Get<HttpClient>());
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
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                EventsCollection.Clear();
                var item = new EventModel
                {
                    Title = "Cats are the best!",
                    Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg",
                    //Date_start = DateTime.Now,
                    Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data"
                };

                EventsCollection.Add(item);
                //await UpdateEvents();
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
        
        private async Task ExecuteAppearItemsCommand()
        {
            //await Shell.Current.GoToAsync("//LoginPage");
         
            try
            {
                EventsCollection.Clear();
                var item = new EventModel
                {
                    Title = "Cats are the best!",
                    Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg",
                    //Date_start = DateTime.Now,
                    Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data"
                };

                EventsCollection.Add(item);
                //await UpdateEvents();
                
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
                throw ex;
            }
        }
        private async Task UpdateEvents()
        {
            var events = await eventService.GetEvents(1);
            foreach (var item in events)
            {
                EventsCollection.Add(item);
            }
        }
    }
}
