using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ErpFidelitas.General.v2.Entities
{
	
     
    public class MovementAccountReceivable
    {
        public int CompanyId { get; set; }
        public long AccountsReceivableId { get; set; }
        public Nullable<long> PersonId { get; set; }
        public Nullable<short> CurrencyId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public short DocumentTypeId { get; set; }
    } 
}