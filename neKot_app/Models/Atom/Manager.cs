using System.Collections.Generic;

namespace neKot_app.Models
{

    public class Manager : Employee
    {                         

        public string Rank { get; set; }        
        public List<Technician> Technicians { get; set; }
        public List<Property> Properties { get; set; }
        public List<Project> Project {get; set;}

    }
}