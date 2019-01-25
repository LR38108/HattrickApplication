using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HattrickApplication.Entities;

namespace HattrickApplication.Entities
{
    public class HattrickApplicationContext : DbContext
    {

        public HattrickApplicationContext() : base("HattrickApplicationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<HattrickApplicationContext>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }         
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TicketItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketItem>()
            .HasRequired(t => t.Ticket)
            .WithMany(m => m.TicketItems)
            .HasForeignKey(k => k.TicketId)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<TicketItem>()
            .HasRequired(t => t.Event)
            .WithMany(m => m.TicketItems)
            .HasForeignKey(k => k.EventId)
            .WillCascadeOnDelete(true);


            modelBuilder.Entity<Event>()
            .HasRequired(e => e.Home)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
            .HasRequired(e => e.Away)
            .WithMany()
            .WillCascadeOnDelete(false);

        }

    }
}