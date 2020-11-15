using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class TrainTicketContext : DbContext
    {
        public TrainTicketContext() : base("TrainTicketContext")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new TrainTicketInitializer());
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}