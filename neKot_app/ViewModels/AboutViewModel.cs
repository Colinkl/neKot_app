using neKot_app.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; }
        public ObservableCollection<NewsModel> News { get; set; }
       

        
        public AboutViewModel()
        {
            
            Title = "News";
            News = new ObservableCollection<NewsModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        private async Task ExecuteLoadItemsCommand()
        {
             //await Shell.Current.GoToAsync("//LoginPage");
            //IsBusy = true;

            //try
            //{
            //    Achivements.Clear();
            //    var items =  Achivements;
            //    foreach (var item in items)
            //    {
            //        Achivements.Add(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
 
    }
}