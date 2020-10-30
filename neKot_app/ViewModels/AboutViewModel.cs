using neKot_app.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using neKot_app.Views;

namespace neKot_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private NewsModel _selectedItem;
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommand {get; }
        public ObservableCollection<NewsModel> News { get; set; }
        public Command<NewsModel> ItemTapped { get; }

        
        public AboutViewModel()
        {
            
            Title = "News";
            News = new ObservableCollection<NewsModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<NewsModel>(OnItemSelected);
            AppearItemsCommand = new Command(async() => await ExecuteAppearItemsCommand());
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        public NewsModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(NewsModel news)
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
                var item = new NewsModel {Title = "Cats are the best!", 
                                           Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg", 
                                           Date =  DateTime.Now, 
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
                var item = new NewsModel {Title = "Cats are the best!", 
                                           Avatar = "https://i1.wp.com/kakoy-prazdnik-segodnya.ru/wp-content/uploads/2019/10/s1200-9.jpg", 
                                           Date =  DateTime.Now, 
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