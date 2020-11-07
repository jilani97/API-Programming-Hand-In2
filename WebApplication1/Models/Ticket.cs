using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Ticket
    {
        public int TicketId { get; set; } 
        public int UserId { get; set; }
        [Required] 
        [MinLength(2)] 
        public string DestinationFrom { get; set; } 

        [Required] 
        [MinLength(2)] 
        public string DestinationTo { get; set; } 
        
        [Required] 
        public DateTime TravelTime { get; set; }
        
        public int AdultsTravelling { get; set; }
        public int StudentsTravelling { get; set; }
        public int ChildrenTravelling { get; set; }

        
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual User User { get; set; }
    }
}