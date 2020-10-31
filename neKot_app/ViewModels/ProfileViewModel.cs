﻿using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        
        string profileImage = "https://i.pinimg.com/736x/27/aa/5a/27aa5a2ff02558ef7d099355ed79b022.jpg";
        public string ProfileImage
        {
            get => profileImage;
            set
            {
                if (value == profileImage)
                {
                    return;
                }
                profileImage = value;
                OnPropertyChanged(nameof(ProfileImage));
            }
        }
        string name = string.Empty;
        public string FullName
        {
            get
            {
                //string fullname = CurrentUser.FirstName + " " + CurrentUser.LastName;
                string fullname = "Иван Иванов";
                return fullname;
            }           
        }
        public ProfileViewModel()
        {
           
        }
    }
}