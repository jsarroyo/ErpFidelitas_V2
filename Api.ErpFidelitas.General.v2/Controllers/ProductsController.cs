using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;


namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class ProductsController : ApiController
    {
		ProductsBL myProducto;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Products/ObtenerUno")]
		public Request ObtenerUno(int CompanyId,int id)
		{
			myProducto = new ProductsBL();

			return myProducto.GetById(CompanyId, id);
		}

		[HttpGet]
		[Route("General/Products/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myProducto = new ProductsBL();

			return myProducto.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Products/CrearUno")]
		public Request CrearUno(Products insertar)
		{
			myProducto = new ProductsBL();

			return myProducto.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/Products/BorrarUno")]
		public Request BorrarUno(int CompanyId, int id)
		{
			myProducto = new ProductsBL();

			return myProducto.Delete(CompanyId, id);
		}	
		[HttpPut]
		[Route("General/Products/ActualizarUno")]
		public Request ActualizarUno(Products insertar)
		{
			myProducto = new ProductsBL();

			return myProducto.UpdateById(insertar);
		}
	}
}
