using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class EventModel
    {
        public int id;
        public string Title { get; set;}
        public string Avatar{ get; set;}
        public string Link{ get; set;}
        public DateTime Date_start{ get; set;}
        public DateTime Date_end{ get; set;}
        public string Location{ get; set;}
        public string Form_of_conducting{ get; set;}
        public string Event_type{ get; set;}
        public string Event_level{ get; set;}
        public string Participant_category{ get; set;}
        public string Organizer{ get; set;}
        public string Curator{ get; set;}
        public List<Direction> Focuses{ get; set;}
        public List<string> Profiles{ get; set;}
    }
}
