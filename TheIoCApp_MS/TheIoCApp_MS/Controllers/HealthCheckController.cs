using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace TheIoCApp_MS.Controllers
{
    [Route("/")]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "version.txt");
            var version = System.IO.File.ReadAllText(filePath).Trim();
            var response = new HealthCheckResponse(version);
            return Ok(response);
        }
    }
    class HealthCheckResponse
    {
        public string Version { get; }
        public HealthCheckResponse(string version)
        {
            Version = version;
        }
    }
}
