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
    public class CurrencyController : BaseController
    {
        Currency currency;
        List<Currency> currencies;
        Response responseClient;
        const string UrlActionPathDetails = "https://localhost:44331/General/Currencys/ObtenerUno?id={0}";
        const string UrlActionPathList = "https://localhost:44331/General/Currencys/ObtenerTodas";
        const string UrlActionPathInsertOne = "https://localhost:44331/General/Currencys/CrearUno";
        const string UrlActionPathUpdate = "https://localhost:44331/General/Currencys/ActualizarUno";
        const string UrlActionPathDelete = "https://localhost:44331/General/Currencys/BorrarUno?id={0}";




        // GET: Currency
        public async Task<ActionResult> Index()
        {
            currencies = new List<Currency>();
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
                        currencies = JsonConvert.DeserializeObject<List<Currency>>(responseClient.Value.ToString());
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
            return View(currencies);
        }

        // GET: Currency/Details/5
        public async Task<ActionResult> Details(int id)
        {
            currency = new Currency();
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
                        currency = JsonConvert.DeserializeObject<Currency>(responseClient.Value.ToString());
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
            return View(currency);

        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currency/Create
        [HttpPost]
        public async Task<ActionResult> Create(Currency collection)
        {
            try
            {
                currency = new Currency();
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

        // GET: Currency/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            currency = new Currency();
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
                        currency = JsonConvert.DeserializeObject<Currency>(responseClient.Value.ToString());
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
            return View(currency);
        }

        // POST: Currency/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Currency collection)
        {
            try
            {
                currency = new Currency();
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

        // GET: Currency/Delete/5
        public  async Task<ActionResult> Delete(int id)
        {
            currency = new Currency();
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
                        currency = JsonConvert.DeserializeObject<Currency>(responseClient.Value.ToString());
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
            return View(currency);
        }

        // POST: Currency/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Currency collection)
        {
            try
            {
                currency = new Currency();
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