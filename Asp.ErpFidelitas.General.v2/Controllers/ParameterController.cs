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
    public class ParameterController : BaseController 
    {
        Parameter parameter;
        List<Parameter> parameters;
        Response responseClient;
        const string UrlActionPathDetails = "https://localhost:44331/General/Parameters/ObtenerUno?id={0}&CompanyId={1}";
        const string UrlActionPathList = "https://localhost:44331/General/Parameters/ObtenerTodas";
        const string UrlActionPathInsertOne = "https://localhost:44331/General/Parameters/CrearUno";
        const string UrlActionPathUpdate = "https://localhost:44331/General/Parameters/ActualizarUno";
        const string UrlActionPathDelete = "https://localhost:44331/General/Parameters/BorrarUno?id={0}&CompanyId={1}";

        // GET: Parameter
        public async Task<ActionResult> Index()
        {
            parameters = new List<Parameter>();
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
                        parameters = JsonConvert.DeserializeObject<List<Parameter>>(responseClient.Value.ToString());
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
            return View(parameters);
        }

        // GET: Parameter/Details/5
        public async Task<ActionResult> Details(int CompanyId,int id)
        {
            parameter = new Parameter();
            responseClient = new Response();

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathDetails, id, CompanyId));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        parameter = JsonConvert.DeserializeObject<Parameter>(responseClient.Value.ToString());
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
            return View(parameter);

        }

        // GET: Parameter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parameter/Create
        [HttpPost]
        public async Task<ActionResult> Create(Parameter collection)
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

        // GET: Parameter/Edit/5
        public  async Task<ActionResult> Edit(int CompanyId,int id)
        {
            parameter = new Parameter();
            responseClient = new Response();

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathDetails, id, CompanyId));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        parameter = JsonConvert.DeserializeObject<Parameter>(responseClient.Value.ToString());
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
            return View(parameter);
        }

        // POST: Parameter/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Parameter collection)
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

        // GET: Parameter/Delete/5
        public async Task< ActionResult> Delete(int CompanyId,int id)
        {
            parameter = new Parameter();
            responseClient = new Response();

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathDetails, id, CompanyId));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        parameter = JsonConvert.DeserializeObject<Parameter>(responseClient.Value.ToString());
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
            return View(parameter);
        }

        // POST: Parameter/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Parameter collection)
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
