using neKot_app.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using neKot_app.Views;
using neKot_app.Services;

namespace neKot_app.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommand {get; }
        public ObservableCollection<NewsModel> News { get; set; }
        public Command<NewsModel> ItemTapped { get; }

        private NewsModel selectedItem;
        private NewsService newsService;
        
        public NewsViewModel()
        {
            Title = "News";
            News = new ObservableCollection<NewsModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AppearItemsCommand = new Command(async() => await ExecuteAppearItemsCommand());
            ItemTapped = new Command<NewsModel>(OnItemSelected);
            newsService = new NewsService(HttpClient);
        }
        public NewsModel SelectedItem
        {
            get => selectedItem;
            set
            {
                SetProperty(ref selectedItem, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(NewsModel news)
        {
            if (news == null)
                return;
            await OpenBrowser(news.Link);      
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await UpdateNews();
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
                await UpdateNews();
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
        private async Task UpdateNews()
        {
            News.Clear();
            var item = new NewsModel
            {
                Title = "Cats are the best!",
                Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg",
                Date = DateTime.Now,
                Link = "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/collectionview/populate-data#populate-a-collectionview-with-data"
            };
            News.Add(item);
        }
        private async Task OpenBrowser(string uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}