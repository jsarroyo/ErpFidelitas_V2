using System.Web;
using System.Web.Mvc;

namespace Asp.ErpFidelitas.General.v2
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
