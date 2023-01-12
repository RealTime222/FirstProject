
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities;

namespace DTO
{
    public class UserDTO 
    {

        public int UserId { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "the length of first name is not valide: MaximumLength = 15,MinimumLength =2")]
        public string FirstName { get; set; } = null!;
        [StringLength(15, MinimumLength = 2, ErrorMessage = "the length of last name is not valide: MaximumLength = 15,MinimumLength =2")]
        public string LastName { get; set; } = null!;
        [EmailAddress(ErrorMessage = "your email is not currect")]
        public string Email { get; set; } = null!;

        public int Password { get; set; }

        public int numOfOrders { get; set; }


    }
}
