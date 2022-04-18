using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Asp.ErpFidelitas.General.v2.Utilities
{
    //public class HttpVerbs<T>
    //{
    //    public async Task GetAsync<T>(string urlPath)
    //    {
    //        T retrunval;
    //        JsonParse<T> jsonParse = new JsonParse<T>();
    //        using (var client = new HttpClient())
    //        {
    //            HttpResponseMessage response = await client.GetAsync(urlPath);
    //            if (response.IsSuccessStatusCode)
    //            {
    //                var str = await response.Content.ReadAsStringAsync();
    //                retrunval = new jsonParse.Deserialize(str);
    //            } 
    //        }
    //        return retrunval;
    //    }
    //}
    //public class JsonParse<T>
    //{
    //    List<T> myListofT;
    //    T myT; 
    //    public List<T> Deserialize(string str)
    //    {
    //        myListofT = new List<T>();
    //        Response responseClient = JsonConvert.DeserializeObject<Response>(str);
    //        if (responseClient.Success)
    //        {
    //            myListofT = JsonConvert.DeserializeObject<List<T>>(responseClient.Value.ToString());
    //        }
    //        return myListofT;
    //    }
    // }
}