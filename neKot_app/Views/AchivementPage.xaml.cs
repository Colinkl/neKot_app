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

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.AppearItemsCommamd.Execute(0);
        }
    }
}
