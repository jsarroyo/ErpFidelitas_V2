//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.ErpFidelitas.General.v2.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persons
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string NumberId { get; set; }
        public Nullable<short> PersonTypeId { get; set; }
        public Nullable<short> PreferedCurrencyId { get; set; }
    
        public virtual Currencys Currencys { get; set; }
        public virtual PersonType PersonType { get; set; }
    }
}
