using System;
using System.Collections.Generic;
using System.Text;

namespace neKot_app.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public int Date { get; set; }
        public DateTime DateGood {
            get
            {
                return new DateTime(1970, 1, 1) + TimeSpan.FromSeconds(Date);
            }        
        }
        public string  Link { get; set; }
    }
}
