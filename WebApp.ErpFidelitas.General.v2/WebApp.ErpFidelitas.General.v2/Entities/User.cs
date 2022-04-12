using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ErpFidelitas.General.v2.Entities
{ 
    public class User
    {
        public int UserId { get; set; }
        public int RolId { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}