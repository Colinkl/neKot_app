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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace neKot_app.ViewModels
{
    class EventsViewModel : BaseViewModel
    {
        private EventService eventService;
        private JobTask _selectedItem;
        public JobTask SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommand { get; }
        public ObservableCollection<JobTask> EventsCollection { get; set; }
        public Command<JobTask> ItemTapped { get; }


        public EventsViewModel()
        {
            Title = "Events";
            EventsCollection = new ObservableCollection<JobTask>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<JobTask>(OnItemSelected);
            AppearItemsCommand = new Command(async () => await ExecuteAppearItemsCommand());
            eventService = new EventService(DependencyService.Get<HttpClient>());
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        async void OnItemSelected(JobTask news)
        {
            if (news == null)
                return;
            await OpenBrowser("");
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                EventsCollection.Clear();
                //var item = new EventModel
                //{
                //    Title = "Cats are the best!",
                //    Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg",
                //    //Date_start = DateTime.Now,
                //    Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data"
                //};

                //EventsCollection.Add(item);
                await UpdateEvents();
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
            try
            {
                EventsCollection.Clear();
                //var item = new EventModel
                //{
                //    Title = "Cats are the best!",
                //    Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg",
                //    //Date_start = DateTime.Now,
                //    Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data"
                //};

                //EventsCollection.Add(item);
                await UpdateEvents();

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
        private async Task OpenBrowser(string uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task UpdateEvents()
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create("http://52.151.246.108/TaskManager/GetTask?EmployeeId=1");
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            //Out.Replace(@"\","");            
            var jobTasks = Utf8Json.JsonSerializer.Deserialize<List<JobTask>>(Out);
            
            foreach (var item in jobTasks)
            {
                EventsCollection.Add(item);
            }            
            return;
        }
    }
}
