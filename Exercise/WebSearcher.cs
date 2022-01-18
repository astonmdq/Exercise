using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Exercise
{
    public class WebSearcher : ISearcher
    {
        private string _province;
        public WebSearcher(string _province)
        {
            this._province = _province;
        }


        public IActionResult Search()
        {
            ControllerBase _controller = new ConcretController();
            try
            {
                WebClient _client = new WebClient();
                JObject _answer = JObject.Parse(_client.DownloadString(string.Concat("https://apis.datos.gob.ar/georef/api/provincias?nombre=", this._province)));
                if (string.Equals(_answer["cantidad"].ToString(), "0"))
                    return _controller.BadRequest("La provincia suministrada es invalida");

                return _controller.Ok(new { Latitud = _answer["provincias"][0]["centroide"]["lat"].ToString(), Longitud = _answer["provincias"][0]["centroide"]["lon"].ToString() });
            }
            catch (Exception ex)
            {
                return _controller.StatusCode(500);
            }
        }
    }

    public class ConcretController : ControllerBase
    {
    }
}
