using neKot_app.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace neKot_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchivementPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        AchivementViewModel _viewModel;

        public AchivementPage()
        {
            InitializeComponent();        

            BindingContext = _viewModel = new AchivementViewModel();
                                   
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
