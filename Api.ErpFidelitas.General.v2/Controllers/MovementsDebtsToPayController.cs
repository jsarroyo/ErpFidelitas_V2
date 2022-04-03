using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class MovementsDebtsToPayController : ApiController
    {
		MovementsDebtsToPayBL movDebsToPay;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/MovementsDebtsToPay/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			movDebsToPay = new MovementsDebtsToPayBL();

			return movDebsToPay.GetById(0, id);
		}
		[HttpGet]
		[Route("General/MovementsDebtsToPay/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			movDebsToPay = new MovementsDebtsToPayBL();

			return movDebsToPay.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/MovementsDebtsToPay/CrearUno")]
		public Request CrearUno(MovementsDebtsToPay insertar)
		{
			movDebsToPay = new MovementsDebtsToPayBL();

			return movDebsToPay.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/MovementsDebtsToPay/BorrarUno")]
		public Request BorrarUno(int id)
		{
			movDebsToPay = new MovementsDebtsToPayBL();

			return movDebsToPay.Delete(0, id);
		}
		[HttpPut]
		[Route("General/MovementsDebtsToPay/ActualizarUno")]
		public Request ActualizarUno(MovementsDebtsToPay insertar)
		{
			movDebsToPay = new MovementsDebtsToPayBL();

			return movDebsToPay.UpdateById(insertar);
		}
	}
}