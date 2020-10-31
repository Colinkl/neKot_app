using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;

namespace neKot_app.Services
{
    public class NewsService
    {
        private HttpClient httpClient;
        private string url = "http://strategico-dev.ru/api/v1/news?page=";

        public NewsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<NewsModel>> GetNews(int pageId)
        {
            var response = await httpClient.GetAsync(url + pageId);
            string respStr = await response.Content.ReadAsStringAsync();
            respStr = Regex.Match(respStr, "data\":.*\"}]").Value;
            List<NewsModel> news = Utf8Json.JsonSerializer.Deserialize<List<NewsModel>>(respStr);
            return news;
        }
    }
}
