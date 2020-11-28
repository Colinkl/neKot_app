using System.Collections.Generic;

namespace neKot_app.Models
{

    public class Technician : Employee
    {                

        public int AccessLevel { get; set; }
        public string Speciality { get; set; }
        public Manager Manager { get; set; }
        public List<Project> Project { get; set; }
    }
}
