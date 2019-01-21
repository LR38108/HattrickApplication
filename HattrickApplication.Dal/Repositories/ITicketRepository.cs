using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        int UpdateTicket(Ticket t);
        IEnumerable<Ticket> UserTickets(int userId);
    }
}
