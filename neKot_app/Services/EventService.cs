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
                    respStr = Regex.Match(respStr, "\"data\":.*}]}]").Value.Replace("data\":", "");
                    respStr = respStr.Replace("id", "Id")
                                     .Replace("title", "Title")
                                     .Replace("avatar", "Avatar")
                                     .Replace("date_start", "Date_start")
                                     .Replace("date_end", "Date_end")
                                     .Replace("location", "Location")
                                     .Replace("form_of_conducting", "Form_of_conducting")
                                     .Replace("event_level", "Event_level")
                                     .Replace("participant_category", "Participant_category")
                                     .Replace("organizer", "Organizer")
                                     .Replace("curator", "Curator")
                                     .Replace("types", "Types")
                                     .Replace("focuses", "Focuses")
                                     .Replace("profiles", "Profiles")
                                     .Replace("event_id", "Event_id");
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
