using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Train
    {
        public DateTime Depart { get; set; }
        public string Track { get; set; }
        public string TrainNumber { get; set; }

        public int TicketPrice { get; set; }
    }
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; } 
        [Required] 
        [MinLength(2)] 
        public string DestinationFrom { get; set; } 

        [Required] 
        [MinLength(2)] 
        public string DestinationTo { get; set; } 
                
        public int AdultsTravelling { get; set; }
        public int StudentsTravelling { get; set; }
        public int ChildrenTravelling { get; set; }

        
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual User User { get; set; }
    }
}