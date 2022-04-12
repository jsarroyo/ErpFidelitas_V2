using System;

namespace Asp.ErpFidelitas.General.v2.Entities
{ 
    public class MovementInventory
    {
        public int CompanyId { get; set; }
        public long InventoryMovementId { get; set; }
        public short DocumentTypeId { get; set; }
        public long ProductId { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime MovementDate { get; set; }
        public System.DateTime MovementLogDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public Nullable<short> CostCurrencyId { get; set; }
        public Nullable<short> UnitPriceCurrencyId { get; set; }
    } 
}