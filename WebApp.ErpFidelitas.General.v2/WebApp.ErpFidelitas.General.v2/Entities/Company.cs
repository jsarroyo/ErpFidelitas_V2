using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ErpFidelitas.General.v2.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Mision { get; set; }
        public string Vision { get; set; }
        public string PrincipalEmail { get; set; }
        public bool Active { get; set; }
    }
}