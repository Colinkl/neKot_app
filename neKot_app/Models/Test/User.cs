﻿using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
