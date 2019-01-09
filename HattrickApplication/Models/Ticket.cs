using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickApplication.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public User User { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public bool IsWinning { get; set; }
        public decimal Bet { get; set; }
        public decimal TotalOdd { get; set; }
        public decimal? PWon { get; set; }
        public virtual ICollection<TicketItem> TicketItems { get; set; }
    }
}