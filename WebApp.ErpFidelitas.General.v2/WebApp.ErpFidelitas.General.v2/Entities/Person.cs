using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ErpFidelitas.General.v2.Entities
{ 
    public class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string NumberId { get; set; }
        public Nullable<short> PersonTypeId { get; set; }
        public Nullable<short> PreferedCurrencyId { get; set; } 
    } 
}