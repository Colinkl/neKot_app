using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Utf8Json;

namespace neKot_app.Services
{
    public class TutorService
    {
        private HttpClient httpClient;
        private string url = "http://strategico-dev.ru/api/v1/mentors?page=";

        public TutorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<TutorModel>> GetTutors(int pageId)
        {
            var response = await httpClient.GetAsync(url + pageId);
            string respStr = await response.Content.ReadAsStringAsync();
            respStr = Regex.Match(respStr, "data\":.*\"}]").Value.Replace("data\":", "");
            respStr = respStr.Replace("{\"data\": ", "").Replace(", \"success\": true}", "");
            //respString = respString
            //    .Replace("direction_name", nameof(TutorModel.DirectionName))
            //    .Replace("result", nameof(TutorModel.Result))
            //    .Replace("child_name", nameof(TutorModel.ChildName)) //There are no more on backend
            //    .Replace("event_name", nameof(TutorModel.EventName))
            //    .Replace("district_name", nameof(TutorModel.DistrictName))
            //    .Replace("year", "Year");
            List<TutorModel> tutors = JsonSerializer.Deserialize<List<TutorModel>>(respStr);
            return tutors;
        }
    }
}
