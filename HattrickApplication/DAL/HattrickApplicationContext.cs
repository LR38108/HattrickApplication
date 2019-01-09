using HattrickApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HattrickApplication.DAL
{
    public class HattrickApplicationContext : DbContext
    {

        public HattrickApplicationContext() : base("HattrickApplicationContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }         
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TiceketItems { get; set; }
        

    }
}