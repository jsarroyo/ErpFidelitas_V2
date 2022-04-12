using System;

namespace Asp.ErpFidelitas.General.v2.Entities

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