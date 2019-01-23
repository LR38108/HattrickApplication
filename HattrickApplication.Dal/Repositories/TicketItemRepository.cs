using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Dal.Repositories;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal.Repositories
{
    public class TicketItemRepository : Repository<TicketItem>, ITicketItemRepository
    {

        public TicketItemRepository(HattrickApplicationContext context) : base(context)
        {
        }


        public TicketItem UpdateTicketItem(TicketItem ticketItem)
        {

            if (ticketItem != null)
            {
                HattrickApplicationContext.Entry(ticketItem).State = EntityState.Modified;
            }
            return ticketItem;
        }

        public HattrickApplicationContext HattrickApplicationContext
        {
            get { return Context as HattrickApplicationContext; }
        }
    }
}
