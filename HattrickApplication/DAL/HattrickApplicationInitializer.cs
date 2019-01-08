using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HattrickApplication.Models;
using System.Globalization;

namespace HattrickApplication.DAL
{
    public class HattrickApplicationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HattrickApplicationContext>
    {
        protected override void Seed(HattrickApplicationContext context)
        {
            var events = new List<Event>
            {
            new Event{SportID=1, Home="Hajduk", Away="Dinamo", Start=DateTime.Parse("04.01.2019 17:00:00"), End=DateTime.Parse("04.01.2019 19:00:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=true},
            new Event{SportID=1, Home="Everton", Away="Arsenal", Start=DateTime.Parse("2019-01-03 14:15:00"), End=DateTime.Parse("03.01.2019 16:15:00"), Result="", T1=1.15m , T2=2.3m, TX=1.08m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=1, Home="Hajduk", Away="Arsenal", Start=DateTime.Parse("2019-01-03 19:30:00"), End=DateTime.Parse("03.01.2019 17:30:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=1, Home="Dinamo", Away="Everton", Start=DateTime.Parse("2019-01-02 20:00:00"), End=DateTime.Parse("02.01.2019 22:00:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=2, Home="Cedevita", Away="Cibona", Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=true},
            new Event{SportID=2, Home="Cedevita", Away="Zadar", Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=true},
            new Event{SportID=2, Home="Zadar", Away="Cibona", Start=DateTime.Parse("2019-01-05 12:10:00"), End=DateTime.Parse("05.01.2019 14:10:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=true},
            new Event{SportID=3, Home="Mladost", Away="Jadran", Start=DateTime.Parse("2019-01-02 13:30:00"), End=DateTime.Parse("02.01.2019 15:30:00"), Result="", T1=1.15m , T2=2.3m, TX=1.09m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=2, Home="Cibona", Away="Cedevita", Start=DateTime.Parse("2019-01-08 13:30:00"), End=DateTime.Parse("08.01.2019 15:30:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=3, Home="Jadran", Away="Mladost", Start=DateTime.Parse("2019-01-07 13:30:00"), End=DateTime.Parse("07.01.2019 15:30:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=1, Home="Rijeka", Away="Zagreb", Start=DateTime.Parse("2019-01-05 13:30:00"), End=DateTime.Parse("05.01.2019 15:30:00"), Result="", T1=1.05m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false},
            new Event{SportID=1, Home="Zagreb", Away="Hajduk", Start=DateTime.Parse("2019-01-09 13:30:00"), End=DateTime.Parse("09.01.2019 15:30:00"), Result="", T1=1.15m , T2=2.3m, TX=1.32m, T1X=1.10m, TX2=1.9m, T12=1.12m, IsTopEvent=false}
            };

            events.ForEach(e => context.Events.Add(e));
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
            new Team{SportID= 1, Name="Hajduk"},
            new Team{SportID= 1, Name="Dinamo"},
            new Team{SportID= 1, Name="Rijeka"},
            new Team{SportID= 1, Name="Zagreb"},
            new Team{SportID= 1, Name="Everton"},
            new Team{SportID= 1, Name="Arsenal"},
            new Team{SportID= 2, Name="Cibona"},
            new Team{SportID= 2, Name="Split"},
            new Team{SportID= 2, Name="Zadar"},
            new Team{SportID= 3, Name="Jadran"},
            new Team{SportID= 3, Name="Mladost"},
            };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();

            var tickets = new List<Ticket>
            {
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 15:30:40"), IsWinning=true, Bet=100, TotalOdd=4.1143872m, PWon=390.87m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 15:40:40"), IsWinning=false, Bet=20, TotalOdd=5.0255m, PWon=95.48m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 15:50:40"), IsWinning=false, Bet=120, TotalOdd=2.3m, PWon=262.2m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 16:00:40"), IsWinning=false, Bet=40, TotalOdd=2.3m, PWon=87.4m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 16:10:40"), IsWinning=false, Bet=10, TotalOdd=2.53m, PWon=24.035m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 16:20:40"), IsWinning=true, Bet=100, TotalOdd=3.4914m, PWon=331.683m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 16:30:40"), IsWinning=false, Bet=100, TotalOdd=2.508m, PWon=230.736m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 16:40:40"), IsWinning=false, Bet=80, TotalOdd=1.9m, PWon=144.4m},
            new Ticket{UserId=1, DateOfSubmission=DateTime.Parse("31.12.2018 16:50:40"), IsWinning=true, Bet=350, TotalOdd=4.18919424m, PWon = 1392.9070848m}

            };
            tickets.ForEach(t => context.Tickets.Add(t));
            context.SaveChanges();

            var ticketItems = new List<TicketItem>
            {
            new TicketItem{TicketID=1, UserID=1, EventID=1, TipType="1", TipOdd=1.15m},
            new TicketItem{TicketID=1, UserID=1, EventID=2, TipType="X", TipOdd=1.32m},
            new TicketItem{TicketID=1, UserID=1, EventID=3, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=1, UserID=1, EventID=4, TipType="12", TipOdd=1.12m},
            new TicketItem{TicketID=1, UserID=1, EventID=5, TipType="1X", TipOdd=1.1m},
            new TicketItem{TicketID=2, UserID=1, EventID=2, TipType="1", TipOdd=1.15m},
            new TicketItem{TicketID=2, UserID=1, EventID=3, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=2, UserID=1, EventID=6, TipType="X2", TipOdd=1.9m},
            new TicketItem{TicketID=3, UserID=1, EventID=2, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=4, UserID=1, EventID=4, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=5, UserID=1, EventID=2, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=5, UserID=1, EventID=3, TipType="12", TipOdd=1.10m},
            new TicketItem{TicketID=6, UserID=1, EventID=2, TipType="X", TipOdd=1.32m},
            new TicketItem{TicketID=6, UserID=1, EventID=4, TipType="1", TipOdd=1.15m},
            new TicketItem{TicketID=6, UserID=1, EventID=6, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=7, UserID=1, EventID=3, TipType="X", TipOdd=1.32m},
            new TicketItem{TicketID=7, UserID=1, EventID=4, TipType="X2", TipOdd=1.9m},
            new TicketItem{TicketID=8, UserID=1, EventID=2, TipType="X2", TipOdd=1.9m},
            new TicketItem{TicketID=8, UserID=1, EventID=2, TipType="X", TipOdd=1.32m},
            new TicketItem{TicketID=8, UserID=1, EventID=3, TipType="2", TipOdd=2.3m},
            new TicketItem{TicketID=9, UserID=1, EventID=4, TipType="12", TipOdd=1.12m},
            new TicketItem{TicketID=9, UserID=1, EventID=5, TipType="1X", TipOdd=1.1m},
            new TicketItem{TicketID=9, UserID=1, EventID=6, TipType="12", TipOdd=1.12m},
            };
            ticketItems.ForEach(t => context.TiceketItems.Add(t));
            context.SaveChanges();

            var users = new List<User>
            {
            new User{ID=1, FirstName="Luka", LastName="Radan", Balance=1443.2m },
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        
        }
    }
}