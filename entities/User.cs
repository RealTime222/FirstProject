using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entities
{

    public partial class user
    {
       
        public int UserId { get; set; }

        [StringLength(15,MinimumLength =2,ErrorMessage = "the length of first name is not valide: MaximumLength = 15,MinimumLength =2")]
        public string FirstName { get; set; } = null!;
        [StringLength(15, MinimumLength = 2, ErrorMessage = "the length of last name is not valide: MaximumLength = 15,MinimumLength =2")]
        public string LastName { get; set; } = null!;
        [EmailAddress(ErrorMessage ="your email is not currect")]
        public string Email { get; set; } = null!;
       
        public int Password { get; set; }

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}