using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
	public class CompanyController : ApiController
	{
		CompaniesBL myCompany;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Compania/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			myCompany = new CompaniesBL(); 

			return myCompany.GetById(id);
		}
		[HttpGet]
		[Route("General/Compania/ObtenerTodas")]
		public Request ObtenerTodas()
		{
			myCompany = new CompaniesBL();

			return myCompany.GetAll();
		}
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Compania/CrearUno")]
		public Request CrearUno(Companies insertar)
		{
			myCompany = new CompaniesBL();

			return myCompany.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/Compania/BorrarUno")]
		public Request BorrarUno(int id)
		{
			myCompany = new CompaniesBL();

			return myCompany.Delete(id);
		}
		[HttpPut]
		[Route("General/Compania/ActualizarUno")]
		public Request ActualizarUno(Companies insertar)
		{
			myCompany = new CompaniesBL();

			return myCompany.UpdateById(insertar);
		}
	}
	
	
}
