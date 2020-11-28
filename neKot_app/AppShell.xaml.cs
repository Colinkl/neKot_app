using System;
using System.Collections.Generic;
using neKot_app.ViewModels;
using neKot_app.Views;
using neKot_app.Views.Chat;
using neKot_app.Views.Profile;
using Xamarin.Forms;

namespace neKot_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AchivementPage), typeof(AchivementPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));
            Routing.RegisterRoute(nameof(TutorsListPage), typeof(TutorsListPage));
            Routing.RegisterRoute(nameof(TutorSelectPage), typeof(TutorSelectPage));
            Routing.RegisterRoute(nameof(RecentChatPage), typeof(RecentChatPage));
            Routing.RegisterRoute(nameof(ChatMessagePage), typeof(ChatMessagePage));
            
            
        }

    }
}
