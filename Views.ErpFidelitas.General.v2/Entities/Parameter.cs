using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ErpFidelitas.General.v2.Entities
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