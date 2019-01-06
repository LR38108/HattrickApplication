using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickApplication.Models
{
    public class TicketItem
    {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }    
        public int EventID { get; set; }
        public string TipType { get; set; }
        public decimal TipOdd { get; set; }

        public virtual Event Event { get; set; }
    }
}