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
        public UserSaveService()
        {
            File.Delete(userPath);
        }
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
                byte[] str = Utf8Json.JsonSerializer.Serialize<User>(user);
                File.WriteAllBytes(userPath, str);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        private User GetSavedUser()
        {
            try
            {
                if (File.Exists(userPath))
                {
                    byte[] str = File.ReadAllBytes(userPath);
                    User user =  Utf8Json.JsonSerializer.Deserialize<User>(str);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        
    }
}
