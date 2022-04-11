using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ErpFidelitas.General.v2.Entities
{
	 
    public class DocumentType
    {
        public short DocumentTypeId { get; set; }
        public string Name { get; set; }
        public short DebitAccountId { get; set; }
        public short CreditAccountId { get; set; }
    } 
}