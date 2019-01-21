using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HattrickApplication.Dal.Repositories;
using HattrickApplication.Entities;

namespace HattrickApplication.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HattrickApplicationContext _context;

        public UnitOfWork(HattrickApplicationContext context)
        {
            _context = context;
            Events = new EventRepository(_context);
            Tickets = new TicketRepository(_context);
            Users = new UserRepository(_context);
            Sports = new SportRepository(_context);
            Teams = new TeamRepository(_context);
        }

        public IEventRepository Events { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public IUserRepository Users { get; private set; }
        public ISportRepository Sports { get; private set; }
        public ITeamRepository Teams { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
