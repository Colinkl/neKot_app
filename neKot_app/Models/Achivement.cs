using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class Achivement
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Direction_name { get; set; }
        public string Result { get; set; }
        public string Child_name { get; set; }
        public string Event_name { get; set; }
        public string District_name { get; set; }
        public int Year { get; set; }
    }
}
