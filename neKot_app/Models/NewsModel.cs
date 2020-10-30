using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class NewsModel
    {
        public int id {get; set;}
        public string Title { get; set; }
        public string Avatar { get; set; }
        public DateTime Date { get; set; }
        public string  Link { get; set; }
    }
}
