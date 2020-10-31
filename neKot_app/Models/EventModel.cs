using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class EventModel
    {
        public int Id;
        public string Title { get; set;}
        public string Avatar{ get; set;}
        public string Link{ get; set; }
        public int DateStartInSeconds{ get; set;}
        public string DateStart
        {
            get
            {
                return (new DateTime(1970, 1, 1) + TimeSpan.FromSeconds(DateStartInSeconds)).ToString("d");
            }
        }
        public int DateEndtInSeconds { get; set;}
        public string Location{ get; set;}
        public string FormOfconducting{ get; set;}
        public string EventType{ get; set;}
        public string EventLevel{ get; set;}
        public string ParticipantCategory{ get; set;}
        public string Organizer{ get; set;}
        public string Curator{ get; set;}
        public List<Direction> Focuses{ get; set;}
        public List<string> Profiles{ get; set;}
    }
}
