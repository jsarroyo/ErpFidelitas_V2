using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.Utilities;
using Api.ErpFidelitas.General.v2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class MovementsAccountsReceivableController : ApiController
    {
		MovementsAccountsReceivableBL movAccRec;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/MovementsAccountsReceivable/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			movAccRec = new MovementsAccountsReceivableBL();

			return movAccRec.GetById(0, id);
		}
		[HttpGet]
		[Route("General/MovementsAccountsReceivable/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			movAccRec = new MovementsAccountsReceivableBL();

			return movAccRec.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/MovementsAccountsReceivable/CrearUno")]
		public Request CrearUno(MovementsAccountsReceivable insertar)
		{
			movAccRec = new MovementsAccountsReceivableBL();

			return movAccRec.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/MovementsAccountsReceivable/BorrarUno")]
		public Request BorrarUno(int id)
		{
			movAccRec = new MovementsAccountsReceivableBL();

			return movAccRec.Delete(0, id);
		}
		[HttpPut]
		[Route("General/MovementsAccountsReceivable/ActualizarUno")]
		public Request ActualizarUno(MovementsAccountsReceivable insertar)
		{
			movAccRec = new MovementsAccountsReceivableBL();

			return movAccRec.UpdateById(insertar);
		}
	}
}