using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.ErpFidelitas.General.v2.App_Start
{
    public class AutorizarFiltro: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session != null)
            {
                if(filterContext.HttpContext.Session["UserId"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        Action = "Index",
                        Controller = "Login"
                    }));
                }
            }
        }
    }
}