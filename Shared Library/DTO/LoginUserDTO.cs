using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library
{
   public class LoginUserDTO
    {
        public int UserID { get; set; }  
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
