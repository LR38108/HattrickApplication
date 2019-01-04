using HattrickApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HattrickApplication.ViewModels
{
    public class TicketTicketItems
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<TicketItem> TicketItems { get; set; }

    }
}