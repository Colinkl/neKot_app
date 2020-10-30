using neKot_app.Models;
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
        public ObservableCollection<Achivement> Achivements { get; set; }
        public AchivementViewModel()
        {
            Title = "Achivements";
            Achivements = new ObservableCollection<Achivement>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
             await Shell.Current.GoToAsync("//LoginPage");
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
    }
}
