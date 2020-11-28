using System;
using System.Collections.Generic;

namespace neKot_app.Models
{
    public class Project
    {
        public int Id { get; set; }

        public Property Property { get; set; }

        public string MalfunctionType { get; set; }
        public string MalfunctionDesc { get; set; }
        public List<Technician> Technicians { get; set; } = new List<Technician>();
        public List<Manager> Managers { get; set; } = new List<Manager>();

        public Employee Creator { get; set; }


        public DateTime CreationTime { get; set; }
        public int Priority { get; set; }

        public string Status { get; set; }
        public DateTime PlannedTime { get; set; }

        public DateTime ComplitionTime { get; set; }        
        public string Comment { get; set; }
        public List<JobTask> Tasks { get; set; }
    }
}