using System;

namespace Asp.ErpFidelitas.General.v2.Entities

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