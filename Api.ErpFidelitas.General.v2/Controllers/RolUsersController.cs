using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;


namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class RolUsersController : ApiController
    {
		RolUsersBL myPersons;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/RolUsers/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			myPersons = new RolUsersBL();

			return myPersons.GetById(0, id);
		}
		[HttpGet]
		[Route("General/RolUsers/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myPersons = new RolUsersBL();

			return myPersons.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/RolUsers/CrearUno")]
		public Request CrearUno(RolUsers insertar)
		{
			myPersons = new RolUsersBL();

			return myPersons.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/RolUsers/BorrarUno")]
		public Request BorrarUno(int id)
		{
			myPersons = new RolUsersBL();

			return myPersons.Delete(0, id);
		}
		[HttpPut]
		[Route("General/RolUsers/ActualizarUno")]
		public Request ActualizarUno(RolUsers insertar)
		{
			myPersons = new RolUsersBL();

			return myPersons.UpdateById(insertar);
		}
	}
}
