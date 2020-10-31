using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Utf8Json;
using System.Threading.Tasks;
using System.Web;

namespace neKot_app.Services
{
    public class AchivementsSearch
    {
        private HttpClient httpClient;
        private string url = "https://edo.72to.ru/genius/children?number=25&surname_firstname=";

        public AchivementsSearch(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Achivement>> GetAchivementsByName(User user)
        {
            string prms = HttpUtility.UrlEncode(user.LastName) + "+" + HttpUtility.UrlEncode(user.FirstName);
            var response = await httpClient.GetAsync(url + prms);
            string respString = await response.Content.ReadAsStringAsync();
            respString = respString.Replace("{\"data\": ", "").Replace(", \"success\": true}", "");
            respString = respString
                .Replace("direction_name", nameof(Achivement.DirectionName))
                .Replace("result", nameof(Achivement.Result))
                .Replace("child_name", nameof(Achivement.ChildName))
                .Replace("event_name", nameof(Achivement.EventName))
                .Replace("district_name", nameof(Achivement.DistrictName))
                .Replace("year", "Year");
            List<Achivement> achivements = JsonSerializer.Deserialize<List<Achivement>>(respString);
            return achivements;
        }
    }
}
