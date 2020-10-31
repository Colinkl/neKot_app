using neKot_app.Models;
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
    public partial class TutorSelectPage : ContentPage
    {
        TutorSelectViewModel _viewModel;
        public TutorSelectPage()
        {
            InitializeComponent();        
            BindingContext = _viewModel = new TutorSelectViewModel();
            //_viewModel.GetTutor.Execute(_viewModel.Id);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OpenTutorProfileCommand.Execute(0);
        }

    }
}