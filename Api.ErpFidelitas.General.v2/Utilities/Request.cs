using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.ErpFidelitas.General.v2.Utilities
{
	public class Request
	{
		public bool Success { get; set; }
		public bool Error { get; set; }
		public bool Warning { get; set; }
		public string Message { get; set; }
		public string Details { get; set; }
		public object Value { get; set; }

		const string ERROR_MSG = "No se ha completado la operación";
		const string WARNING_MSG = "Se ha completado la operación, con advertencias.";
		const string SUCCESS_MSG = "Se ha completado la operación";

		public Request DoWarning(string details = "")
		{
			Warning = true;
			Details = details;
			Message = WARNING_MSG;
			return this;
		}
		public Request DoError(string details = "")
		{
			Error = true;
			Message = ERROR_MSG;
			Details = details;

			return this;
		}
		public Request DoSuccess(object Data = null, string details = "")
		{
			Success = true;
			Message = SUCCESS_MSG;
			Details = details;
			Value = Data;
			return this;
		}

	}
}