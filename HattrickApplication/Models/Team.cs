using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickApplication.Models
{
    public class Team
    {
        public int ID { get; set; }
        public Sport Sport { get; set; }
        public string Name { get; set; }
    }
}