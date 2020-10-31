using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace neKot_app.Services
{
    public class EventService
    {
        private HttpClient httpClient;
        private string url = "http://strategico-dev.ru/api/v1/events?page=";

        public EventService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<EventModel>> GetEvents(int pageId)
        {
            try
            {
                var response = await httpClient.GetAsync(url + pageId);
                string respStr = await response.Content.ReadAsStringAsync();
                respStr = Regex.Match(respStr, "\"data\":.*}]}]").Value;
                respStr = respStr.Replace("data\":", "");
                respStr = respStr.Replace("id", nameof(EventModel.Id))
                                 .Replace("link", nameof(EventModel.Link))
                                 .Replace("title", nameof(EventModel.Title))
                                 .Replace("avatar", nameof(EventModel.Avatar))
                                 .Replace("date_start", nameof(EventModel.DateStartInSeconds))
                                 .Replace("date_end", nameof(EventModel.DateEndtInSeconds))
                                 .Replace("location", nameof(EventModel.Location))
                                 .Replace("form_of_conducting", nameof(EventModel.FormOfconducting))
                                 .Replace("event_level", nameof(EventModel.EventLevel))
                                 .Replace("participant_category", nameof(EventModel.ParticipantCategory))
                                 .Replace("organizer", nameof(EventModel.Organizer))
                                 .Replace("curator", nameof(EventModel.Curator));
                                 //.Replace("types", "Types")
                                 //.Replace("focuses", "Focuses") Cant parse JSON to enum
                                 //.Replace("profiles", "Profiles")
                respStr = respStr.Remove(0, 1);
                char c = respStr[0];
                List<EventModel> news = Utf8Json.JsonSerializer.Deserialize<List<EventModel>>(respStr);
                return news;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
