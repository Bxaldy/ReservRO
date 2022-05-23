using System;
using System.Collections.Generic;
using System.Text;

namespace ReservRO.Models
{
   public class UserModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string UseType { get; set; }
    }
}
