﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }
        public DateTime Depart { get; set; }
        public string Track { get; set; }
        public string TrainNumber { get; set; }

        public int TicketPrice { get; set; }
    }
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; } 
        public int UserId { get; set; }
        [Required] 
        [MinLength(2)] 
        public string DestinationFrom { get; set; } 

        [Required] 
        [MinLength(2)] 
        public string DestinationTo { get; set; } 
        
        public Train TravelRoute { get; set; }
        
        public int AdultsTravelling { get; set; }
        public int StudentsTravelling { get; set; }
        public int ChildrenTravelling { get; set; }

        
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual User User { get; set; }
    }
}