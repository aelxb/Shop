using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int ID_User { get; set; }
        public string Email_User { get; set; }
        public int Password_User { get; set; }
        public string Avatar_User { get; set; }
    }
}
