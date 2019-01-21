using System;
using System.Collections.Generic;

namespace HattrickApplication.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public bool IsWinning { get; set; }
        public decimal Bet { get; set; }
        public decimal TotalOdd { get; set; }
        public decimal? PotentialWinnings { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TicketItem> TicketItems { get; set; }
    }
}