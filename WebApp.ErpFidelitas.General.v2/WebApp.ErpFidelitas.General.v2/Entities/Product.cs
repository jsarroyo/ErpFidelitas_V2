using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ErpFidelitas.General.v2.Entities
{
	 
    public class Product
    {
        public int CompanyId { get; set; }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public Nullable<short> UnitCostCurrencyId { get; set; }
        public Nullable<short> UnitPriceCurrencyId { get; set; }
    } 
}