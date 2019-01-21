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
    public class EventRepository : Repository<Event>, IEventRepository
    {

        public EventRepository(HattrickApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Event> GetTopEvents()
        {
            return HattrickApplicationContext.Events.Where(e => e.IsTopEvent == true).ToList();
        }

        public Event UpdateEvent(Event eventEntity)
        {

            if (eventEntity != null)
            {
                HattrickApplicationContext.Entry(eventEntity).State = EntityState.Modified;
            }
            return eventEntity;
        }

        public HattrickApplicationContext HattrickApplicationContext
        {
            get { return Context as HattrickApplicationContext; }
        }
    }
}
