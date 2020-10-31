using neKot_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace neKot_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel viewModel;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProfileViewModel();
                                   
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.CheckAuthCommand.Execute(0);
            LblName.Text = viewModel.FullName;
        }
    }
}