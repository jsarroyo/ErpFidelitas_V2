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
    public class MovementDebtToPayController : BaseController
    {
        MovementDebtToPay debtToPay;
        List<MovementDebtToPay> movements;
        Response responseClient;
        const string UrlActionPathDetails = "https://localhost:44331/General/MovementsDebtsToPay/ObtenerUno?id={0}";
        const string UrlActionPathList = "https://localhost:44331/General/MovementsDebtsToPay/ObtenerTodas";
        const string UrlActionPathInsertOne = "https://localhost:44331/General/MovementsDebtsToPay/CrearUno";
        const string UrlActionPathUpdate = "https://localhost:44331/General/MovementsDebtsToPay/ActualizarUno";
        const string UrlActionPathDelete = "https://localhost:44331/General/MovementsDebtsToPay/BorrarUno?id={0}";
        // GET: MovementDebtToPay
        public async Task<ActionResult> Index()
        {
            movements = new List<MovementDebtToPay>();
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
                        movements = JsonConvert.DeserializeObject<List<MovementDebtToPay>>(responseClient.Value.ToString());
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
            return View(movements);
        }

        // GET: MovementDebtToPay/Details/5
        public async Task<ActionResult> Details(int id)
        {
            debtToPay = new MovementDebtToPay();
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
                        debtToPay = JsonConvert.DeserializeObject<MovementDebtToPay>(responseClient.Value.ToString());
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
            return View(debtToPay);

        }

        // GET: MovementDebtToPay/Create
        public ActionResult Create()
        {
            
            return View(new MovementDebtToPay());
        }

        // POST: MovementDebtToPay/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovementDebtToPay collection)
        {
            try
            {
                debtToPay = new MovementDebtToPay();
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

        // GET: MovementDebtToPay/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            debtToPay = new MovementDebtToPay();
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
                        debtToPay = JsonConvert.DeserializeObject<MovementDebtToPay>(responseClient.Value.ToString());
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
            return View(debtToPay);
        }

        // POST: MovementDebtToPay/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MovementDebtToPay collection)
        {
            try
            {
                debtToPay = new MovementDebtToPay();
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

        // GET: MovementDebtToPay/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            debtToPay = new MovementDebtToPay();
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
                        debtToPay = JsonConvert.DeserializeObject<MovementDebtToPay>(responseClient.Value.ToString());
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
            return View(debtToPay);
        }

        // POST: MovementDebtToPay/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, MovementDebtToPay collection)
        {
            try
            {
                debtToPay = new MovementDebtToPay();
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
