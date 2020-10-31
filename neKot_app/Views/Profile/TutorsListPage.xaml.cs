using neKot_app.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace neKot_app.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorsListPage : ContentPage
    {
        TutorListViewModel _viewModel;
        public TutorsListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TutorListViewModel();
                                   
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();          
            _viewModel.AppearItemsCommamd.Execute(0);
        }
    }
}