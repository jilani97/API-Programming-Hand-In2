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
            var tickets = new List<Ticket>
            {
            new Ticket{AdultsTravelling = 1, DestinationFrom = "Oslo S", DestinationTo = "Lillestrom", UserId = 1},
            new Ticket{DestinationFrom = "Oslo S", DestinationTo = "Hauketo", StudentsTravelling = 1, UserId = 2},
            };
            tickets.ForEach(s => context.Tickets.Add(s));
            
            var receipts = new List<Receipt>
            {
            new Receipt{PurchaseDate =  DateTime.Parse("2020-11-01"), TicketId = 1},
            new Receipt{PurchaseDate =  DateTime.Parse("2020-11-02"), TicketId = 2},
            };
            receipts.ForEach(s => context.Receipts.Add(s));
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            base.Seed(context);
        }
    }
}