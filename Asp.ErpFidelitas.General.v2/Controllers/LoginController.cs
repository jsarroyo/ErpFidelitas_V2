using Asp.ErpFidelitas.General.v2.App_Start;
using Asp.ErpFidelitas.General.v2.Entities;
using Asp.ErpFidelitas.General.v2.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Asp.ErpFidelitas.General.v2.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<ActionResult> Index(User user)
        {

            try
            {
                var responseClient = new Response();

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/Authentication/Login?email={user.Email}&password={user.Password}");
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        User userLoged = JsonConvert.DeserializeObject<User>(responseClient.Value.ToString());
                        Session["UserId"] = userLoged.UserId;
                        Session["RolId"] = userLoged.RolId;
                        Session["UserName"] = userLoged.UserName;
                        Session["FirstName"] = userLoged.FirstName;
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseClient.Details;
                        return View(new User());
                    }

                }

                return RedirectToAction("Index","Home");
            }
            catch (Exception error)
            {
                ViewBag.ErrorInfo = ERRORMESSAGE;
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;
                return View("Error");
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult CrearCuenta()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<ActionResult> CrearCuenta(User user)
        {
            try
            {
                var responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(user);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/Authentication/Register",stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = responseClient.Details;
                        return View(new User());
                    }

                }
            }
            catch (Exception error)
            {
                ViewBag.ErrorInfo = ERRORMESSAGE;
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;
                return View("Error");
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}