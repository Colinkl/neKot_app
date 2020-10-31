using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace neKot_app.Services
{
    public class UserSaveService
    {
        private string userPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "currentUser.json");
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = GetSavedUser();
                }
                return currentUser;
            }
            private set { }
        }

        public void SaveUser(User user)
        {
            try
            {
                currentUser = user;
                File.WriteAllText(userPath, Utf8Json.JsonSerializer.Serialize(currentUser).ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        private User GetSavedUser()
        {
            if (File.Exists(userPath))
            {
                return Utf8Json.JsonSerializer.Deserialize<User>(File.ReadAllText(userPath));
            }
            else
            {
                return null;
            }
        }
    }
}
