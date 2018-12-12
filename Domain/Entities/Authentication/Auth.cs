using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Authentication
{
   public class Auth
    { 
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public long? langId { get; set; }
    }
}
