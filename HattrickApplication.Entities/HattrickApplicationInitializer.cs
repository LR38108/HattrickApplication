using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Globalization;
using HattrickApplication.Entities;

namespace HattrickApplication.Entities
{
    public class HattrickApplicationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HattrickApplicationContext>
    {
        protected override void Seed(HattrickApplicationContext context)
        {
            var users = new List<User>
            {
            new User{Id=1, FirstName="Luka", LastName="Radan", Balance=1443.2m },
            };
            users.ForEach(u => context.Users.Add(u));
         

            var sports = new List<Sport>
            {
            new Sport{Id=1, Name="Nogomet"},
            new Sport{Id=2, Name="Košarka"},
            new Sport{Id=3, Name="Vaterpolo"},
            new Sport{Id=4, Name="Tenis"}

            };
            sports.ForEach(s => context.Sports.Add(s));

            var teams = new List<Team>
            {
            new Team{Id=1, SportId = 1, Name="Hajduk"},
            new Team{Id=2, SportId = 1, Name="Dinamo"},
            new Team{Id=3, SportId = 1, Name="Rijeka"},
            new Team{Id=4, SportId = 1, Name="Zagreb"},
            new Team{Id=5, SportId = 1, Name="Everton"},
            new Team{Id=6, SportId = 1, Name="Arsenal"},
            new Team{Id=7, SportId = 2, Name="Cibona"},
            new Team{Id=8, SportId = 2, Name="Cedevita"},
            new Team{Id=9, SportId = 2, Name="Split"},
            new Team{Id=10,SportId = 2, Name="Zadar"},
            new Team{Id=11,SportId = 3, Name="Jadran"},
            new Team{Id=12,SportId = 3, Name="Mladost"},
            new Team{Id=13,SportId = 4, Name="R.Nadal"},
            new Team{Id=14,SportId = 4, Name="R.Federer"},
            };
            teams.ForEach(t => context.Teams.Add(t));

            var events = new List<Event>
            {
            new Event{Id=1, SportId = 1, HomeId = 1,  AwayId=2,  Start=DateTime.Parse("04.01.2019 17:00:00"), End=DateTime.Parse("04.01.2019 19:00:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{Id=2, SportId = 1, HomeId = 5,  AwayId=6, Start=DateTime.Parse("2019-01-03 14:15:00"), End=DateTime.Parse("03.01.2019 16:15:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.08m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=3, SportId = 1, HomeId = 1,  AwayId=6,  Start=DateTime.Parse("2019-01-03 19:30:00"), End=DateTime.Parse("03.01.2019 17:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=4, SportId = 1, HomeId = 2,  AwayId=5,  Start=DateTime.Parse("2019-01-02 20:00:00"), End=DateTime.Parse("02.01.2019 22:00:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=5, SportId = 2, HomeId = 8,  AwayId=7,  Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{Id=6, SportId = 2, HomeId = 8,  AwayId=10, Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{Id=7, SportId = 2, HomeId = 10, AwayId=7,  Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{Id=8, SportId = 3, HomeId = 12, AwayId=11, Start=DateTime.Parse("2019-01-02 13:30:00"), End=DateTime.Parse("02.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.09m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=9, SportId = 2, HomeId = 9,  AwayId= 8, Start=DateTime.Parse("2019-01-08 13:30:00"), End=DateTime.Parse("08.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=10,SportId = 3, HomeId = 11, AwayId= 12, Start=DateTime.Parse("2019-01-07 13:30:00"), End=DateTime.Parse("07.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=11,SportId = 1, HomeId = 3,  AwayId= 4, Start=DateTime.Parse("2019-01-05 13:30:00"), End=DateTime.Parse("05.01.2019 15:30:00"), Result="", Tip1=1.05m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=12,SportId = 1, HomeId = 4,  AwayId= 1, Start=DateTime.Parse("2019-01-09 13:30:00"), End=DateTime.Parse("09.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{Id=13,SportId = 4, HomeId = 13,  AwayId= 14, Start=DateTime.Parse("2019-01-28 13:30:00"), End=DateTime.Parse("28.01.2019 17:30:00"), Result="", Tip1=1.15m , Tip2=2.3m},
            new Event{Id=14,SportId = 4, HomeId = 14,  AwayId= 13, Start=DateTime.Parse("2019-01-09 13:30:00"), End=DateTime.Parse("09.01.2019 17:30:00"), Result="", Tip1=1.15m , Tip2=2.3m}
            };                           

            events.ForEach(e => context.Events.Add(e));           

            var tickets = new List<Ticket>
            {
            new Ticket{Id=1, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 15:30:40"), IsWinning=true, Bet=100, TotalOdd=4.1143872m, PotentialWinnings=390.87m},
            new Ticket{Id=2, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 15:40:40"), IsWinning=false, Bet=20, TotalOdd=5.0255m, PotentialWinnings=95.48m},
            new Ticket{Id=3, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 15:50:40"), IsWinning=false, Bet=120, TotalOdd=2.3m, PotentialWinnings=262.2m},
            new Ticket{Id=4, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 16:00:40"), IsWinning=false, Bet=40, TotalOdd=2.3m, PotentialWinnings=87.4m},
            new Ticket{Id=5, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 16:10:40"), IsWinning=false, Bet=10, TotalOdd=2.53m, PotentialWinnings=24.035m},
            new Ticket{Id=6, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 16:20:40"), IsWinning=true, Bet=100, TotalOdd=3.4914m, PotentialWinnings=331.683m},
            new Ticket{Id=7, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 16:30:40"), IsWinning=false, Bet=100, TotalOdd=2.508m, PotentialWinnings=230.736m},
            new Ticket{Id=8, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 16:40:40"), IsWinning=false, Bet=80, TotalOdd=1.9m, PotentialWinnings=144.4m},
            new Ticket{Id=9, UserId= 1, DateOfSubmission=DateTime.Parse("31.12.2018 16:50:40"), IsWinning=true, Bet=350, TotalOdd=4.18919424m, PotentialWinnings = 1392.9070848m}

            };
            tickets.ForEach(t => context.Tickets.Add(t));

            var ticketItems = new List<TicketItem>
            {
            new TicketItem{Id=1,TicketId=1, EventId=1, TipType="1", TipOdd=1.15m},
            new TicketItem{Id=2,TicketId=1, EventId=3, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=3,TicketId=1, EventId=4, TipType="12", TipOdd=1.12m},
            new TicketItem{Id=4,TicketId=1, EventId=5, TipType="1X", TipOdd=1.1m},
            new TicketItem{Id=5,TicketId=2, EventId=2, TipType="1", TipOdd=1.15m},
            new TicketItem{Id=6,TicketId=2, EventId=3, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=7,TicketId=2, EventId=6, TipType="X2", TipOdd=1.9m},
            new TicketItem{Id=8,TicketId=3, EventId=2, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=9,TicketId=4, EventId=4, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=10,TicketId=5,EventId=2, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=11,TicketId=5,EventId=3, TipType="12", TipOdd=1.10m},
            new TicketItem{Id=12,TicketId=6,EventId=2, TipType="X", TipOdd=1.32m},
            new TicketItem{Id=13,TicketId=6,EventId=4, TipType="1", TipOdd=1.15m},
            new TicketItem{Id=14,TicketId=6,EventId=6, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=14,TicketId=7,EventId=3, TipType="X", TipOdd=1.32m},
            new TicketItem{Id=15,TicketId=7,EventId=4, TipType="X2", TipOdd=1.9m},
            new TicketItem{Id=16,TicketId=8,EventId=2, TipType="X2", TipOdd=1.9m},
            new TicketItem{Id=17,TicketId=8,EventId=2, TipType="X", TipOdd=1.32m},
            new TicketItem{Id=18,TicketId=8,EventId=3, TipType="2", TipOdd=2.3m},
            new TicketItem{Id=19,TicketId=9,EventId=4, TipType="12", TipOdd=1.12m},
            new TicketItem{Id=20,TicketId=9,EventId=5, TipType="1X", TipOdd=1.1m},
            new TicketItem{Id=21,TicketId=9,EventId=6, TipType="12", TipOdd=1.12m},
            };
            ticketItems.ForEach(t => context.TicketItems.Add(t));


            context.SaveChanges();           
        
        }
    }
}