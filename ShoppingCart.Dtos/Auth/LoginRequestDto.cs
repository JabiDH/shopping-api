using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Dtos.Auth
{
    public class LoginRequestDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public long ExpireOnInSeconds { private get; set; }

        public long ExpireOn { get { return this.ExpireOnInSeconds <= 0 ? 60 * 60 : this.ExpireOnInSeconds; } }


    }
}
