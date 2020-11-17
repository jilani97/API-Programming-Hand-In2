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
            new User{FirstName="Ola", LastName="Nordmann", PhoneNumber= "12345678",Email="CarsonM@gmail.com"},
            };

            users.ForEach(s => context.Users.Add(s));
           
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