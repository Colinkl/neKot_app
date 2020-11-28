using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Web;

namespace neKot_app.Services
{
    public class AuthService
    {
        private HttpClient httpClient;
        private string url = "";

        public AuthService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public  string AuthInService(string login, string password)
        {
            
            return null;
        }
    }
}
