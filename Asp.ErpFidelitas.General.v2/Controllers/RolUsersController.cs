using Asp.ErpFidelitas.General.v2.Entities;
using Asp.ErpFidelitas.General.v2.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Asp.ErpFidelitas.General.v2.Controllers
{
    public class RolUsersController : BaseController
    {
        RolUsers company;
        List<RolUsers> companies;
        Response responseClient;
        const string UrlActionPathDetails = "https://localhost:44331/General/RolUsers/ObtenerUno?id={0}";
        const string UrlActionPathList = "https://localhost:44331/General/RolUsers/ObtenerTodas";
        const string UrlActionPathInsertOne = "https://localhost:44331/General/RolUsers/CrearUno";
        const string UrlActionPathUpdate = "https://localhost:44331/General/RolUsers/ActualizarUno";
        const string UrlActionPathDelete = "https://localhost:44331/General/RolUsers/BorrarUno?id={0}";

        // GET: RolUsers
        public async Task<ActionResult> Index()
        {
            companies = new List<RolUsers>();
            responseClient = new Response();

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(UrlActionPathList);
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        companies = JsonConvert.DeserializeObject<List<RolUsers>>(responseClient.Value.ToString());
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
            return View(companies);
        }

        // GET: RolUsers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            company = new RolUsers();
            responseClient = new Response();

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathDetails, id));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        company = JsonConvert.DeserializeObject<RolUsers>(responseClient.Value.ToString());
                    }
                }
            }
            catch (Exception error)
            {
                ViewBag.ErrorInfo = "Error al intentar contactar con eservidor de datos.";
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;
                return View("Error");
            }
            return View(companies);

        }

        // GET: RolUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsers/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(UrlActionPathInsertOne, stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
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

        // GET: RolUsers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolUsers/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(UrlActionPathUpdate, stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
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

        // GET: RolUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolUsers/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync(string.Format(UrlActionPathDetails, id));

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
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
    }
}
