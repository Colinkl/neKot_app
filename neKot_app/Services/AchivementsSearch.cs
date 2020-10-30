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
        private HttpClient html = new HttpClient();
        private string url = "https://edo.72to.ru/genius/children?number=25&surname_firstname=";
        
        public async Task<List<Achivement>> GetAchivementsByName(User user)
        {
            string prms = HttpUtility.UrlEncode(user.LastName) + "+" + HttpUtility.UrlEncode(user.FirstName);
            var response = await html.GetAsync(url + prms);
            string respString = await response.Content.ReadAsStringAsync();
            respString = respString.Replace("{\"data\": ", "").Replace(", \"success\": true}", "");
            respString = respString
                .Replace("direction_name", "DirectionName")
                .Replace("result", "Result")
                .Replace("child_name", "ChildName")
                .Replace("event_name", "EventName")
                .Replace("district_name", "DistrictName")
                .Replace("year", "Year");
            List<Achivement> achivements = JsonSerializer.Deserialize<List<Achivement>>(respString);
            return achivements;
        }
    }
}
