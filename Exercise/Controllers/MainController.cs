using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {

        private string _finalPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(5);
        private ConstructorSearcher _searcher;

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        

       

        // GET api/<MainController>/5
        [HttpGet("{province}")]
        public IActionResult Get(string province)
        {
            if (_logger != null)
                _logger.LogInformation(string.Concat("Requesting coordinates of province ",province));
            _searcher = new ConstructorSearcher(new WebSearcher(province));
            return _searcher.Search();
        }

        // POST api/<MainController>
        [HttpPost]
        public IActionResult Post([FromHeader] string user,[FromHeader]string password)
        {
            if (_logger != null)
                _logger.LogInformation(string.Concat("Requesting access for user ", user));
            _searcher = new ConstructorSearcher(new FileSearcher(user, password));
            return _searcher.Search();
        }

    }
}
