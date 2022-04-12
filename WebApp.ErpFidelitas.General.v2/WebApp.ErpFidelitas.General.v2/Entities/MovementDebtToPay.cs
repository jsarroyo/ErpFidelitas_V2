using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ErpFidelitas.General.v2.Entities
{
	
     
    public class MovementDebtToPay
    {
        public int CompanyId { get; set; }
        public long DebtsToPayId { get; set; }
        public Nullable<long> PersonId { get; set; }
        public Nullable<short> CurrencyId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public short DocumentTypeId { get; set; }
    } 
}