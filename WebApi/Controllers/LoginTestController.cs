using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginTestController : ControllerBase
    {
       
        private readonly ILogger<LoginTestController> _logger;

        public LoginTestController(ILogger<LoginTestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Get()
        {
            return "Hello ......";
        }
    }
}
