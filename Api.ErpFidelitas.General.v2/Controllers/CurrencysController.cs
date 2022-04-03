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
    public class CurrencysController : ApiController
    {
		CurrencysBL currency;
		//[FiltroSeguridad]
		[HttpGet]
		[Route("General/Currencys/ObtenerUno")]
		public Request ObtenerUno(int id)
		{
			currency = new CurrencysBL();

			return currency.GetById(id);
		}
	
		//[FiltroSeguridad]
		[HttpPost]
		[Route("General/Currencys/CrearUno")]
		public Request CrearUno(Currencys insertar)
		{
			currency = new CurrencysBL();

			return currency.Insert(insertar);
		}
		[HttpDelete]
		[Route("General/Currencys/BorrarUno")]
		public Request BorrarUno(int id)
		{
			currency = new CurrencysBL();

			return currency.Delete(id);
		}
		[HttpPut]
		[Route("General/Currencys/ActualizarUno")]
		public Request ActualizarUno(Currencys insertar)
		{
			currency = new CurrencysBL();
			return currency.UpdateById(insertar);
		}
	}
}
