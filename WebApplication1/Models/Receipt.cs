using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; } 

        [Required] 
        public DateTime PurchaseDate { get; set; } 

        public TimeTableRoutes TicketPurchased { get; set; }

        public virtual Ticket Ticket { get; set; }

    }
}