using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class ParametersController : ApiController
    {
		ParametersBL myPersons;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Parameters/ObtenerUno")]
		public Request ObtenerUno(int CompanyId,int id)
		{
			myPersons = new ParametersBL();

			return myPersons.GetById(CompanyId, id);
		}
		[HttpGet]
		[Route("General/Parameters/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myPersons = new ParametersBL();

			return myPersons.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Parameters/CrearUno")]
		public Request CrearUno(Parameters insertar)
		{
			myPersons = new ParametersBL();

			return myPersons.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/Parameters/BorrarUno")]
		public Request BorrarUno(int CompanyId,  int id)
		{
			myPersons = new ParametersBL();

			return myPersons.Delete(CompanyId, id);
		}
		[HttpPut]
		[Route("General/Parameters/ActualizarUno")]
		public Request ActualizarUno(Parameters insertar)
		{
			myPersons = new ParametersBL();

			return myPersons.UpdateById(insertar);
		}
	}
}