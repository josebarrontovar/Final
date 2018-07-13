using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using WebFinal.Models;

namespace WebFinal.Controllers.Api
{
    public class ServicesController : ApiController
    {


        public IHttpActionResult GetInfo()
        {
            int id = 4004156;

            string content = Task.Run(()=> GetData(id)).Result;
            //List<ClimaCity> post = JsonConvert.DeserializeObject<List<ClimaCity>>(content);
            //foreach (var info in post)
            //{

            //}

            return Ok();
        }



        [Route("api/Comments/{Id}/Posts")]
        private static async Task<string> GetData(int id)
        {
    
            string url = "http://api.openweathermap.org/data/2.5/weather?id="+id+"&appid=410aa6ce7a2e29f13f3b4dd7b9eec4f1";
            HttpClient client = new HttpClient();
            string content = await client.GetStringAsync(url);
            return content;
        }



    }
}
