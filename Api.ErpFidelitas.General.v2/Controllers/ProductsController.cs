using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;


namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class ProductsController : ApiController
    {
		ProductsBL myPersons;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Products/ObtenerUno")]
		public Request ObtenerUno(int Company,int id)
		{
			myPersons = new ProductsBL();

			return myPersons.GetById(Company, id);
		}
		[HttpGet]
		[Route("General/Products/ObtenerTodas")]
		public Request ObtenerTodas(int Company)
		{
			myPersons = new ProductsBL();

			return myPersons.GetAll(Company);
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Products/CrearUno")]
		public Request CrearUno(Products insertar)
		{
			myPersons = new ProductsBL();

			return myPersons.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/Products/BorrarUno")]
		public Request BorrarUno(int Company, int id)
		{
			myPersons = new ProductsBL();

			return myPersons.Delete(Company, id);
		}
		[HttpPut]
		[Route("General/Products/ActualizarUno")]
		public Request ActualizarUno(Products insertar)
		{
			myPersons = new ProductsBL();

			return myPersons.UpdateById(insertar);
		}
	}
}
