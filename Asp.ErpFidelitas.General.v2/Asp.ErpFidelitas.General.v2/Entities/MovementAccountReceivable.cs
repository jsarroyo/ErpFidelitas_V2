
using System;

namespace Asp.ErpFidelitas.General.v2.Entities
{
	
     
    public class MovementAccountReceivable
    {
        public int CompanyId { get; set; }
        public long AccountsReceivableId { get; set; }
        public long? PersonId { get; set; }
        public Nullable<short> CurrencyId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public short DocumentTypeId { get; set; }
    } 
}