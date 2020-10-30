using neKot_app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Utf8Json;
using System.Threading.Tasks;

namespace neKot_app.Services
{
    public class AchivementsSearch
    {
        private HttpClient html = new HttpClient();
        private string url = "https://edo.72to.ru/genius/children?number=25&surname_firstname=";
        
        public async Task<List<Achivement>> GetAchivementsByName(User user)
        {
            string response = (await html.GetAsync(url + user.FirstName + user.LastName)).Content.ToString();
            List<Achivement> achivements = JsonSerializer.Deserialize<List<Achivement>>(response);
            return achivements;
        }
    }
}
