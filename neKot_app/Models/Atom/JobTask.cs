using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public enum Statuses
    {
        New,
        Choosed,
        Working,
        Vefication,
        Done
    }

    public class JobTask
    {
        public int Id { get; set; }
        public Statuses Status { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public Employee Executor { get; set; }
        public Employee Verifier { get; set; }
        public DateTime CreationTime {get; set;}
        public DateTime DeadLine { get; set; }
        public DateTime DoneTime { get; set; }
        public int Priority { get; set; }
        
    }
}
