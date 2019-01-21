using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Dal.Repositories;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(HattrickApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Ticket> UserTickets(int userId)
        {
            return HattrickApplicationContext.Tickets.Where(t => t.User.Id == userId);
        }

        public int UpdateTicket(Ticket ticket)
        {
            int result = -1;

            if (ticket != null)
            {
                HattrickApplicationContext.Entry(ticket).State = EntityState.Modified;
                HattrickApplicationContext.SaveChanges();
                result = ticket.Id;
            }
            return result;
        }

        public HattrickApplicationContext HattrickApplicationContext
        {
            get { return Context as HattrickApplicationContext; }
        }
    }
}
