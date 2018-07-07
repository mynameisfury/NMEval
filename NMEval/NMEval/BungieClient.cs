using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace NMEval
{
    public class BungieClient
    {
         public void QueryApi()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", "61cf5518bb3c4fbc91acbb28b572e477");

                var response = client.GetAsync("https://www.bungie.net/platform/Content/GetContentType/Weapons").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                Console.WriteLine(item.Response.data.inventoryItem.itemName); //Gjallarhorn
            }
        }
    }
}