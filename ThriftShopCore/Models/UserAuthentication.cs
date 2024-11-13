using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftShopCore.Models
{
    public class UserAuthentication
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength=3 , ErrorMessage = "The password must be more than 8 characters long and less than 50 ")]
        public string? Password { get; set; }
    }
}
