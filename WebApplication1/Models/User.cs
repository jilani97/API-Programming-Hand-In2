using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    { 
        [Key]
        public int UserId { get; set; } 

        [Required] 
        [MinLength(2)] 
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Phone] 
        public string PhoneNumber { get; set; } 

        [EmailAddress] 
        public string Email { get; set; } 
        
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}