using System.Collections.Generic;

namespace neKot_app.Models
{
    public class Property
    {
        public int Id { get; set; }        


        public Machine Machine { get; set; }


        public string Location {get; set;}

        public string Department { get; set; }


        public string Status { get; set; }
        
        public Manager Manager { get; set; }
        public List<Project> Project {get; set;}

    }
}