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
    public class PersonsController : ApiController
    {
		PersonsBL person;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Persons/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			person = new PersonsBL();

			return person.GetById(id);
		}

		[HttpGet]
		[Route("General/Persons/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			person = new PersonsBL();

			return person.GetAll();
		}

		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Persons/CrearUno")]
		public Request CrearUno(Persons insertar)
		{
			person = new PersonsBL();

			return person.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/Persons/BorrarUno")]
		public Request BorrarUno(int id)
		{
			person = new PersonsBL();

			return person.Delete(id);
		}
		[HttpPut]
		[Route("General/Persons/ActualizarUno")]
		public Request ActualizarUno(Persons insertar)
		{
			person = new PersonsBL();
			return person.UpdateById(insertar);
		}
	}
}
