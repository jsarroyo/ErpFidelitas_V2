using Api.ErpFidelitas.General.v2.BusinessLogic;
using Api.ErpFidelitas.General.v2.DataBase;
using Api.ErpFidelitas.General.v2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.ErpFidelitas.General.v2.Controllers
{
    public class AuthenticationController : ApiController
    {
        AuthenticationBL auth;
        // GET: Authentication
        [HttpGet]
        [Route("Authentication/Login")]
        public Request Login(string email, string password)
        {
            auth = new AuthenticationBL();
            return auth.Login(email,password);
        }

        // POST: Authentication/Create
        [HttpPost]
        [Route("Authentication/Register")]
        public Request Register(Users user)
        {
            auth = new AuthenticationBL();

            return auth.Register(user);

        }
    }
}
