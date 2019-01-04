using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickApplication.Models
{
    public enum Tip
    {
        T1,
        T2,
        TX,
        T1X,
        TX2,
        T12
    }
    public class TicketItem
    {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public Tip TipType { get; set; }
        public decimal TipOdd { get; set; }
    }
}