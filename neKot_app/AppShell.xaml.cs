using System;
using System.Collections.Generic;
using neKot_app.ViewModels;
using neKot_app.Views;
using Xamarin.Forms;

namespace neKot_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
