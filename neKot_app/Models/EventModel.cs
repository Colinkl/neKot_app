using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class EventModel
    {
        public int id;
        public string Title;
        public string Avatar;
        public string Link;
        public DateTime Date_start;
        public DateTime Date_end;
        public string Location;
        public string Form_of_conducting;
        public string Event_type;
        public string Event_level;
        public string Participant_category;
        public string Organizer;	
        public string Curator;
        public List<Direction> Focuses;	
        public List<string> Profiles;
    }
}
