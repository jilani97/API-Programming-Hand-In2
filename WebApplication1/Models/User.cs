using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    { 
        public int UserId { get; set; } 

        [Required] 
        [MinLength(2)] 
        public string Name { get; set; } 

        [Phone] 
        public string PhoneNumber { get; set; } 

        [EmailAddress] 
        public string Email { get; set; } 
        
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}