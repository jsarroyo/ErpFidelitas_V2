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
using System.Web.Mvc;

namespace Asp.ErpFidelitas.General.v2.Controllers
{
    [AutorizarFiltro]
    public class MovementAccountReceivableController : BaseController
    {
        MovementAccountReceivable movAccRec;
        List<MovementAccountReceivable> movAccReceivables;
        Response responseClient;

        const string UrlActionPathAllPersonas = "https://localhost:44331/General/Persons/ObtenerTodas";
        const string UrlActionPathAllCurrencys = "https://localhost:44331/General/Currencys/ObtenerTodas";
        const string UrlActionPathAllTiposDoc = "https://localhost:44331/General/DocumentTypes/ObtenerTodas";

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
        public async Task<ActionResult> Create()
        {

            ViewBag.ListaTiposDocumento = new List<SelectListItem>();
            ViewBag.ListaMonedas = new List<SelectListItem>();
            ViewBag.ListaPersonas = new List<SelectListItem>();

            ViewBag.ListaTiposDocumento = await ObtenerComboTiposDocumento();
            ViewBag.ListaMonedas = await ObtenerComboMonedas();
            ViewBag.ListaPersonas = await ObtenerComboPersonasAsync();
            //TempData["MensajesExito"] = EstadoOperacion ? "Operacion realizada exitosamente!" : "";

            return View();
        }

        private async Task<List<SelectListItem>> ObtenerComboPersonasAsync()
        {
            List<SelectListItem> keyValuePairs = new List<SelectListItem>();

            List<Person> persons = new List<Person>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathAllPersonas));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        persons = JsonConvert.DeserializeObject<List<Person>>(responseClient.Value.ToString());
                    }
                    foreach (var item in persons)
                    {

                        keyValuePairs.Add(new SelectListItem { Text = $"{item.FirstName} {item.LastName}", Value = item.PersonId.ToString() });
                    }
                }
            }
            catch (Exception error)
            {
                ViewBag.ErrorInfo = ERRORMESSAGE;
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;

            }

            return keyValuePairs;
        }
        private async Task<List<SelectListItem>> ObtenerComboMonedas()
        {
            List<SelectListItem> keyValuePairs = new List<SelectListItem>();

            List<Currency> products = new List<Currency>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathAllCurrencys));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        products = JsonConvert.DeserializeObject<List<Currency>>(responseClient.Value.ToString());
                    }
                    foreach (var item in products)
                    {

                        keyValuePairs.Add(new SelectListItem { Text = item.Name, Value = item.CurrencyId.ToString() });
                    }
                }
            }
            catch (Exception error)
            {
                ViewBag.ErrorInfo = ERRORMESSAGE;
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;

            }

            return keyValuePairs;
        }
        private async Task<List<SelectListItem>> ObtenerComboTiposDocumento()
        {
            List<SelectListItem> keyValuePairs = new List<SelectListItem>();

            List<DocumentType> products = new List<DocumentType>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathAllTiposDoc));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        products = JsonConvert.DeserializeObject<List<DocumentType>>(responseClient.Value.ToString());
                    }
                    foreach (var item in products.Where(d => d.Name.Contains("CXC")))
                    {

                        keyValuePairs.Add(new SelectListItem { Text = item.Name, Value = item.DocumentTypeId.ToString() });
                    }
                }
            }
            catch (Exception error)
            {
                ViewBag.ErrorInfo = ERRORMESSAGE;
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;

            }

            return keyValuePairs;
        }


        // POST: MovementAccountReceivable/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovementDebtToPay collection, long[] PersonaId, short[] TipoDocumentId, decimal[] Monto, short[] Moneda)
        {

            //fila = '<tr class="odd">';
            //fila = fila + '<td class="sorting_1"> <input type="text" class="form-control-plaintext" name="PersonaId" value="' + $("#ddlPersona").val() + '"></td>';
            //fila = fila + '<td > <input class="form-control-plaintext" type="text" name="TipoDocumentId" value="' + $("#ddlTipoDocumento").val() + '"></td>';
            //fila = fila + '<td > <input class="form-control-plaintext" type="text" name="Monto" value="' + $("#txtMonto").val() + '"></td>';
            //fila = fila + '<td > <input class="form-control-plaintext" type="text" name="Moneda" value="' + $("#ddlMoneda").val() + '"></td>';
            //fila = fila + '</tr>';

            try
            {
                responseClient = new Response();
                movAccRec = new MovementAccountReceivable();
                for (int i = 0; i < PersonaId.Length; i++)
                {
                    movAccRec = new MovementAccountReceivable()
                    {
                        CompanyId = 1,
                        DocumentTypeId = TipoDocumentId[i],
                        PersonId = PersonaId[i],
                        CurrencyId = Moneda[i],
                        Amount = Monto[i]
                    };

                    using (var client = new HttpClient())
                    {
                        var json = JsonConvert.SerializeObject(movAccRec);
                        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(UrlActionPathInsertOne, stringContent);

                        string resultContent = response.Content.ReadAsStringAsync().Result;
                    }
                }
                return RedirectToAction("Create");
                //return View();
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
