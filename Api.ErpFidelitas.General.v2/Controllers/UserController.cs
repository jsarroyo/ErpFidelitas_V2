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
    public class UserController : ApiController
    {
		UserBL myUser;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Users/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			myUser = new UserBL();

			return myUser.GetById(id);
		}
		[HttpGet]
		[Route("General/Users/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myUser = new UserBL();

			return myUser.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Users/CrearUno")]
		public Request CrearUno(Users insertar)
		{
			myUser = new UserBL();

			return myUser.Insert(insertar);
		}

		[HttpDelete]
		[Route("General/Users/BorrarUno")]
		public Request BorrarUno(int id)
		{
			myUser = new UserBL();

			return myUser.Delete(id);
		}
		[HttpPut]
		[Route("General/Users/ActualizarUno")]
		public Request ActualizarUno(Users insertar)
		{
			myUser = new UserBL();

			return myUser.UpdateById(insertar);
		}

}

}
