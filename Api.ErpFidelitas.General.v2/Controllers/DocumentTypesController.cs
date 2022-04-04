using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class DocumentTypesController : ApiController
    {
		DocumentTypesBL DocumentT;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/DocumentTypes/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			DocumentT = new DocumentTypesBL();

			return DocumentT.GetById(id);
		}

		[HttpGet]
		[Route("General/DocumentTypes/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			DocumentT = new DocumentTypesBL();

			return DocumentT.GetAll();
		}

		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/DocumentTypes/CrearUno")]
		public Request CrearUno(DocumentTypes insertar)
		{
			DocumentT = new DocumentTypesBL();

			return DocumentT.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/DocumentTypes/BorrarUno")]
		public Request BorrarUno(int id)
		{
			DocumentT = new DocumentTypesBL();

			return DocumentT.Delete(id);
		}
		[HttpPut]
		[Route("General/DocumentTypes/ActualizarUno")]
		public Request ActualizarUno(DocumentTypes insertar)
		{
			DocumentT = new DocumentTypesBL();
			return DocumentT.UpdateById(insertar);
		}
	}
}
