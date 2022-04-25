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
    public class MovementInventoryController : BaseController
    {
        MovementInventory movementInventory;
        List<MovementInventory> movements;
        Response responseClient;
        const string UrlActionPathAllProducts = "https://localhost:44331/General/Products/ObtenerTodas";
        const string UrlActionPathAllCurrencys = "https://localhost:44331/General/Currencys/ObtenerTodas";
        const string UrlActionPathAllTiposDoc = "https://localhost:44331/General/DocumentTypes/ObtenerTodas";

        const string UrlActionPathDetails = "https://localhost:44331/General/MovementsInventory/ObtenerUno?id={0}";
        const string UrlActionPathList = "https://localhost:44331/General/MovementsInventory/ObtenerTodas";
        const string UrlActionPathInsertOne = "https://localhost:44331/General/MovementsInventory/CrearUno";
        const string UrlActionPathUpdate = "https://localhost:44331/General/MovementsInventory/ActualizarUno";
        const string UrlActionPathDelete = "https://localhost:44331/General/MovementsInventory/BorrarUno?id={0}";
        // GET: MovementInventory
        public async Task<ActionResult> Index()
        {
            movements = new List<MovementInventory>();
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
                        movements = JsonConvert.DeserializeObject<List<MovementInventory>>(responseClient.Value.ToString());
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

        // GET: MovementInventory/Details/5
        public async Task<ActionResult> Details(int id)
        {
            movementInventory = new MovementInventory();
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
                        movementInventory = JsonConvert.DeserializeObject<MovementInventory>(responseClient.Value.ToString());
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
            return View(movementInventory);

        }

        // GET: MovementInventory/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ListaTiposDocumento = new List<SelectListItem>();
            ViewBag.ListaMonedas = new List<SelectListItem>();
            ViewBag.ListaArticulos = new List<SelectListItem>();

            ViewBag.ListaTiposDocumento = await ObtenerComboTiposDocumento();
            ViewBag.ListaMonedas = await ObtenerComboMonedas();
            ViewBag.ListaArticulos = await ObtenerComboArticulosAsync();

            return View();
        }

		private async Task<List<SelectListItem>> ObtenerComboArticulosAsync()
		{
            List<SelectListItem> keyValuePairs = new List<SelectListItem>();
             
            List<Product> products = new List<Product>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format(UrlActionPathAllProducts));
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        products = JsonConvert.DeserializeObject<List<Product>>(responseClient.Value.ToString());
                    }
					foreach (var item in products)
					{

                        keyValuePairs.Add (new SelectListItem { Text = item.Name,Value = item.ProductId.ToString() } );
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
                    foreach (var item in products.Where(d => d.Name.Contains("inv")))
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
        // POST: MovementInventory/Create
        [HttpPost]
        public async Task<ActionResult> Create(MovementInventory collection, short[] DocumentTypeId, int[] ProductId, decimal[] Quantity, decimal[] UnitCost, short[] CostCurrencyId)
        {
            try
            {
                var sss = HttpContext.Request["DocumentTypeId"];
                responseClient = new Response();
                movementInventory = new MovementInventory();
                for (int i=0;i< DocumentTypeId.Length;i++)
                {
                    movementInventory = new MovementInventory()
                    {
                        CompanyId = 1,
                        DocumentTypeId = DocumentTypeId[i],
                        ProductId = ProductId[i],
                        Quantity = Quantity[i],
                        UnitCost = UnitCost[i],
                        CostCurrencyId = CostCurrencyId[i],
                        MovementDate = DateTime.Now
                    };

                    using (var client = new HttpClient())
                    {
                        var json = JsonConvert.SerializeObject(movementInventory);
                        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(UrlActionPathInsertOne, stringContent);

                        string resultContent = response.Content.ReadAsStringAsync().Result;
                    }
                }
                return View();
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

        // GET: MovementInventory/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            movementInventory = new MovementInventory();
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
                        movementInventory = JsonConvert.DeserializeObject<MovementInventory>(responseClient.Value.ToString());
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
            return View(movementInventory);
        }

        // POST: MovementInventory/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, MovementInventory collection)
        {
            try
            {
                movementInventory = new MovementInventory();
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

        // GET: MovementInventory/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            movementInventory = new MovementInventory();
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
                        movementInventory = JsonConvert.DeserializeObject<MovementInventory>(responseClient.Value.ToString());
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
            return View(movementInventory);
        }

        // POST: MovementInventory/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, MovementInventory collection)
        {
            try
            {
                movementInventory = new MovementInventory();
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
