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
            context.SaveChanges();

            var sports = new List<Sport>
            {
            new Sport{Name="Nogomet"},
            new Sport{Name="Košarka"},
            new Sport{Name="Vaterpolo"}

            };
            sports.ForEach(s => context.Sports.Add(s));
            context.SaveChanges();

            var teams = new List<Team>
            {
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 1), Name="Hajduk"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 1), Name="Dinamo"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 1), Name="Rijeka"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 1), Name="Zagreb"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 1), Name="Everton"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 1), Name="Arsenal"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 2), Name="Cibona"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 2), Name="Cedevita"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 2), Name="Split"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 2), Name="Zadar"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 3), Name="Jadran"},
            new Team{Sport = context.Sports.FirstOrDefault(s => s.Id == 3), Name="Mladost"},
            };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();


            var events = new List<Event>
            {
            new Event{SportId=1, HomeId = 1,  AwayId=2,  Start=DateTime.Parse("04.01.2019 17:00:00"), End=DateTime.Parse("04.01.2019 19:00:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{SportId=1, HomeId = 5,  AwayId=6, Start=DateTime.Parse("2019-01-03 14:15:00"), End=DateTime.Parse("03.01.2019 16:15:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.08m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=1, HomeId = 1,  AwayId=6,  Start=DateTime.Parse("2019-01-03 19:30:00"), End=DateTime.Parse("03.01.2019 17:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=1, HomeId = 2,  AwayId=5,  Start=DateTime.Parse("2019-01-02 20:00:00"), End=DateTime.Parse("02.01.2019 22:00:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=2, HomeId = 8,  AwayId=7,  Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{SportId=2, HomeId = 8,  AwayId=10, Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{SportId=2, HomeId = 10, AwayId=7,  Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=true},
            new Event{SportId=3, HomeId = 12, AwayId=11, Start=DateTime.Parse("2019-01-02 13:30:00"), End=DateTime.Parse("02.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.09m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=2, HomeId = 9,  AwayId= 8, Start=DateTime.Parse("2019-01-08 13:30:00"), End=DateTime.Parse("08.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=3, HomeId = 11, AwayId= 12, Start=DateTime.Parse("2019-01-07 13:30:00"), End=DateTime.Parse("07.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=1, HomeId = 3,  AwayId= 4, Start=DateTime.Parse("2019-01-05 13:30:00"), End=DateTime.Parse("05.01.2019 15:30:00"), Result="", Tip1=1.05m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false},
            new Event{SportId=1, HomeId = 4,  AwayId= 1, Start=DateTime.Parse("2019-01-09 13:30:00"), End=DateTime.Parse("09.01.2019 15:30:00"), Result="", Tip1=1.15m , Tip2=2.3m, TipX=1.32m, Tip1X=1.10m, TipX2=1.9m, Tip12=1.12m, IsTopEvent=false}
            };                           

            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();            
           

            var tickets = new List<Ticket>
            {
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 15:30:40"), IsWinning=true, Bet=100, TotalOdd=4.1143872m, PWon=390.87m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 15:40:40"), IsWinning=false, Bet=20, TotalOdd=5.0255m, PWon=95.48m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 15:50:40"), IsWinning=false, Bet=120, TotalOdd=2.3m, PWon=262.2m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 16:00:40"), IsWinning=false, Bet=40, TotalOdd=2.3m, PWon=87.4m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 16:10:40"), IsWinning=false, Bet=10, TotalOdd=2.53m, PWon=24.035m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 16:20:40"), IsWinning=true, Bet=100, TotalOdd=3.4914m, PWon=331.683m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 16:30:40"), IsWinning=false, Bet=100, TotalOdd=2.508m, PWon=230.736m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 16:40:40"), IsWinning=false, Bet=80, TotalOdd=1.9m, PWon=144.4m},
            new Ticket{User= context.Users.FirstOrDefault(u => u.Id == 1), DateOfSubmission=DateTime.Parse("31.12.2018 16:50:40"), IsWinning=true, Bet=350, TotalOdd=4.18919424m, PWon = 1392.9070848m}

            };
            tickets.ForEach(t => context.Tickets.Add(t));
            context.SaveChanges();

            var ticketItems = new List<TicketItem>
            {
            new TicketItem{TicketId=1, Event=context.Events.FirstOrDefault(e => e.Id == 1), TipType="1", TipOdd=1.15m},
            new TicketItem{TicketId=1, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="X", TipOdd=1.32m},
            new TicketItem{TicketId=1, Event=context.Events.FirstOrDefault(e => e.Id == 3), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=1, Event=context.Events.FirstOrDefault(e => e.Id == 4), TipType="12", TipOdd=1.12m},
            new TicketItem{TicketId=1, Event=context.Events.FirstOrDefault(e => e.Id == 5), TipType="1X", TipOdd=1.1m},
            new TicketItem{TicketId=2, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="1", TipOdd=1.15m},
            new TicketItem{TicketId=2, Event=context.Events.FirstOrDefault(e => e.Id == 3), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=2, Event=context.Events.FirstOrDefault(e => e.Id == 6), TipType="X2", TipOdd=1.9m},
            new TicketItem{TicketId=3, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=4, Event=context.Events.FirstOrDefault(e => e.Id == 4), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=5, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=5, Event=context.Events.FirstOrDefault(e => e.Id == 3), TipType="12", TipOdd=1.10m},
            new TicketItem{TicketId=6, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="X", TipOdd=1.32m},
            new TicketItem{TicketId=6, Event=context.Events.FirstOrDefault(e => e.Id == 4), TipType="1", TipOdd=1.15m},
            new TicketItem{TicketId=6, Event=context.Events.FirstOrDefault(e => e.Id == 6), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=7, Event=context.Events.FirstOrDefault(e => e.Id == 3), TipType="X", TipOdd=1.32m},
            new TicketItem{TicketId=7, Event=context.Events.FirstOrDefault(e => e.Id == 4), TipType="X2", TipOdd=1.9m},
            new TicketItem{TicketId=8, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="X2", TipOdd=1.9m},
            new TicketItem{TicketId=8, Event=context.Events.FirstOrDefault(e => e.Id == 2), TipType="X", TipOdd=1.32m},
            new TicketItem{TicketId=8, Event=context.Events.FirstOrDefault(e => e.Id == 3), TipType="2", TipOdd=2.3m},
            new TicketItem{TicketId=9, Event=context.Events.FirstOrDefault(e => e.Id == 4), TipType="12", TipOdd=1.12m},
            new TicketItem{TicketId=9, Event=context.Events.FirstOrDefault(e => e.Id == 5), TipType="1X", TipOdd=1.1m},
            new TicketItem{TicketId=9, Event=context.Events.FirstOrDefault(e => e.Id == 6), TipType="12", TipOdd=1.12m},
            };
            ticketItems.ForEach(t => context.TiceketItems.Add(t));
            context.SaveChanges();
            
        
        }
    }
}