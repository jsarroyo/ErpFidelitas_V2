using System;

namespace Asp.ErpFidelitas.General.v2.Entities
 
{
	 
    public class Parameter
    {
        public int CompanyId { get; set; }
        public int ParameterId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Details { get; set; }
    } 
}