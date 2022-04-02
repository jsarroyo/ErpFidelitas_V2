using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class PersonsTypeController : ApiController
    {
        PersonsTypeBL myPersons;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/PersonsType/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			myPersons = new PersonsTypeBL(); 

			return myPersons.GetById(0,id);
		}
		[HttpGet]
		[Route("General/PersonsType/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myPersons = new PersonsTypeBL();

			return myPersons.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/PersonsType/CrearUno")]
		public Request CrearUno(PersonType insertar)
		{
			myPersons = new PersonsTypeBL();

			return myPersons.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/PersonsType/BorrarUno")]
		public Request BorrarUno(int id)
		{
			myPersons = new PersonsTypeBL();

			return myPersons.Delete(0,id);
		}
		[HttpPut]
		[Route("General/PersonsType/ActualizarUno")]
		public Request ActualizarUno(PersonType insertar)
		{
			myPersons = new PersonsTypeBL();

			return myPersons.UpdateById(insertar);
		}
    }
}
