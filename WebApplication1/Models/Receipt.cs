using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; } 
        public int TicketId { get; set; }

        [Required] 
        public DateTime PurchaseDate { get; set; } 

        public virtual Ticket Ticket { get; set; }

    }
}