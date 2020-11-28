
using System;
using System.Collections.Generic;
using System.Text;


namespace neKot_app.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Login {get; set;}
        public string Password { get; set; }
        public int EmployeeId { get; set; }        
        public Employee Employee { get; set; }
    }
}
