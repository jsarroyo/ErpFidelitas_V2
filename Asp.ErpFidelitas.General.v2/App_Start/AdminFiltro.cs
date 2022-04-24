using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.ErpFidelitas.General.v2.App_Start
{
    public class AdminFiltro: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                if (filterContext.HttpContext.Session["RolId"].ToString() != "1")
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "Forbidden"
                    };
                }
            }
        }
    }
}