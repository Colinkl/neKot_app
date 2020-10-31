using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public List<Direction>  Directions {get; set;}
        public string District { get; set; }
        public List<Achivement> Achievements { get; set; }
        public int TutorID {get; set;}
    }
}
