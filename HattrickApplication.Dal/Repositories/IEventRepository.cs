using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetTopEvents();
        Event UpdateEvent(Event e);
    }
}
