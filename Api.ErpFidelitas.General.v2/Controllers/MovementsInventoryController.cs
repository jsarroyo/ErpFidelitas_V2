using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class MovementsInventoryController : ApiController
    {
		MovementsInventoryBL myPersons;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/MovementsInventory/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.GetById(0, id);
		}
		[HttpGet]
		[Route("General/MovementsInventory/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/MovementsInventory/CrearUno")]
		public Request CrearUno(MovementsInventory insertar)
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/MovementsInventory/BorrarUno")]
		public Request BorrarUno(int id)
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.Delete(0, id);
		}
		[HttpPut]
		[Route("General/MovementsInventory/ActualizarUno")]
		public Request ActualizarUno(MovementsInventory insertar)
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.UpdateById(insertar);
		} 
		[HttpGet]
		[Route("General/MovementsInventory/ReporteCostos")]
		public Request ReporteCostos(int CompanyId, DateTime desde, DateTime hasta, int id=0)
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.ReporteCostos(CompanyId,desde, hasta, id);
		}
		[HttpGet]
		[Route("General/MovementsInventory/ReporteSaldos")]
		public Request ReporteSaldos(int CompanyId,DateTime desde, DateTime hasta, int id = 0)
		{
			myPersons = new MovementsInventoryBL();

			return myPersons.ReporteSaldos(CompanyId,desde, hasta, id);
		}
	}
}