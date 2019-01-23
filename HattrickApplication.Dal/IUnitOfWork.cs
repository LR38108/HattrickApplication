using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Dal.Repositories;

namespace HattrickApplication.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        ITicketRepository Tickets { get; }
        IUserRepository Users { get; }
        ISportRepository Sports { get; }
        ITeamRepository Teams { get; }
        ITicketItemRepository TicketItems { get; }
        int Complete();
    }
}
