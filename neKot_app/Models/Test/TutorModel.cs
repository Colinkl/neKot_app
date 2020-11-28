using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class TutorModel
    {
        public int id {get; set;}
        public string first_name { get; set; }
        public string last_name { get; set; }
        public List<Direction>  Directions {get; set;}
        public string avatar { get; set; }
        public string telegram_link { get; set; }
        public string vk_link { get; set; }
        public string whatsapp_link { get; set; }
        public string email { get; set; }
        public string description { get; set; }
    }
}
