using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace neKot_app.Services
{
    public class NewsService
    {
        private HttpClient httpClient;
        private string url = "";

        public NewsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<NewsModel>> GetNews()
        {
            var response = await httpClient.GetAsync(url);
            string respStr = await response.Content.ReadAsStringAsync();
            List<NewsModel> news = Utf8Json.JsonSerializer.Deserialize<List<NewsModel>>(respStr);
            return news;
        }
    }
}
