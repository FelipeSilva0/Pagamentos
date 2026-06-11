using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.API.Health;
using Pagamentos.API.Models;
using System;
using System.Reflection;

namespace Pagamentos.API.Controllers
{
    [Route("health")]
    public class HealthController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDatabaseHealthCheck _dbHealthCheck;

        public HealthController(IWebHostEnvironment env, IDatabaseHealthCheck dbHealthCheck)
        {
            _env = env;
            _dbHealthCheck = dbHealthCheck;
        }

        [HttpGet("details")]
        public IActionResult GetDetails()
        {
            bool canConnect;
            try
            {
                canConnect = _dbHealthCheck.CanConnect();
            }
            catch
            {
                canConnect = false;
            }

            var response = new HealthDetailsResponse(
                Status: "ok",
                Application: "Pagamentos.API",
                Environment: _env.EnvironmentName,
                TimestampUtc: DateTime.UtcNow.ToString("o"),
                Version: Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0",
                Database: new DatabaseHealthInfo(canConnect)
            );

            return Ok(response);
        }
    }
}
