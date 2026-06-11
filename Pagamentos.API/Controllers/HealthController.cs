using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Pagamentos.API.Controllers
{
    [Route("health")]
    public class HealthController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public HealthController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("details")]
        public IActionResult GetDetails()
        {
            return Ok(new
            {
                status = "ok",
                environment = _env.EnvironmentName,
                timestamp = DateTime.UtcNow
            });
        }
    }
}
