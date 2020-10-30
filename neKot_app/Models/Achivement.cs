using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class Achivement
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string DirectionName { get; set; }
        public string Result { get; set; }
        public string ChildName { get; set; }
        public string EventName { get; set; }
        public string DistrictName { get; set; }
        public int Year { get; set; }
    }
}
