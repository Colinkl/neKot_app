using System.ComponentModel;
using Xamarin.Forms;
using neKot_app.ViewModels;

namespace neKot_app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}