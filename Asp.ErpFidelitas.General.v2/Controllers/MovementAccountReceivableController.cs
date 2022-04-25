using Asp.ErpFidelitas.General.v2.App_Start;
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
    [AutorizarFiltro]
    public class MovementAccountReceivableController : BaseController
    {
        MovementAccountReceivable movAccRec;
        List<MovementAccountReceivable> movAccReceivables;
        Response responseClient;
        const string UrlActionPathDetails = "https://localhost:44331/General/MovementsAccountsReceivable/ObtenerUno?id={0}";
        const string UrlActionPathList = "https://localhost:44331/General/MovementsAccountsReceivable/ObtenerTodas";
        const string UrlActionPathInsertOne = "https://localhost:44331/General/MovementsAccountsReceivable/CrearUno";
        const string UrlActionPathUpdate = "https://localhost:44331/General/MovementsAccountsReceivable/ActualizarUno";
        const string UrlActionPathDelete = "https://localhost:44331/General/MovementsAccountsReceivable/BorrarUno?id={0}";

        // GET: MovementAccountReceivable
        public async Task<ActionResult> Index()
        {
            movAccReceivables = new List<MovementAccountReceivable>();
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
                        movAccReceivables = JsonConvert.DeserializeObject<List<MovementAccountReceivable>>(responseClient.Value.ToString());
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
            return View(movAccReceivables);
        }

        // GET: MovementAccountReceivable/Details/5
        public async Task<ActionResult> Details(int id)
        {
            movAccRec = new MovementAccountReceivable();
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
                        movAccRec = JsonConvert.DeserializeObject<MovementAccountReceivable>(responseClient.Value.ToString());
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
            return View(movAccRec);

        }

        // GET: MovementAccountReceivable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementAccountReceivable/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovementAccountReceivable collection)
        {
            try
            {
                movAccRec = new MovementAccountReceivable();
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

        // GET: MovementAccountReceivable/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            movAccRec = new MovementAccountReceivable();
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
                        movAccRec = JsonConvert.DeserializeObject<MovementAccountReceivable>(responseClient.Value.ToString());
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
            return View(movAccRec);
        }

        // POST: MovementAccountReceivable/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MovementAccountReceivable collection)
        {
            try
            {
                movAccRec = new MovementAccountReceivable();
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

        // GET: MovementAccountReceivable/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            movAccRec = new MovementAccountReceivable();
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
                        movAccRec = JsonConvert.DeserializeObject<MovementAccountReceivable>(responseClient.Value.ToString());
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
            return View(movAccRec);
        }

        // POST: MovementAccountReceivable/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, MovementAccountReceivable collection)
        {
            try
            {
                movAccRec = new MovementAccountReceivable();
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
