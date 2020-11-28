using System.Collections.Generic;

namespace neKot_app.Models
{
    public class Machine
    {

        public string Model { get; set; }

        public string Type { get; set; }
        public int AccessLevel { get; set; }


        public string Speciality { get; set; }
        
        public List<Property> PropList { get; set; }
        public List<Malfuntions> Malfuntions { get; set; }

    }
}