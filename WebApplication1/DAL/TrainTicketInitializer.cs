using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class TrainTicketInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<TrainTicketContext>
    {
        protected override void Seed(TrainTicketContext context)
        {
            var users = new List<User>
            {
            new User{Name="Carson",PhoneNumber= "12345678",Email="CarsonM@gmail.com"},
            new User{Name="Ola",PhoneNumber= "342123143",Email="OlaN@gmail.com"},
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var tickets = new List<Ticket>
            {
            new Ticket{AdultsTravelling = 1,TravelTime = DateTime.Parse("2020-11-01"), DestinationFrom = "Oslo S", DestinationTo = "Lillestrom", UserId = 1},
            new Ticket{TravelTime = DateTime.Parse("2020-11-02"), DestinationFrom = "Oslo S", DestinationTo = "Hauketo", StudentsTravelling = 1, UserId = 2},
            };
            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();
            
            var receipts = new List<Receipt>
            {
            new Receipt{PurchaseDate =  DateTime.Parse("2020-11-01"), TicketId = 1},
            new Receipt{PurchaseDate =  DateTime.Parse("2020-11-02"), TicketId = 2},
            };
            receipts.ForEach(s => context.Receipts.Add(s));
            context.SaveChanges();
        }
    }
}