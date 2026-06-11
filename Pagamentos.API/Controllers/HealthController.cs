using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.API.Health;
using Pagamentos.API.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetDetails(CancellationToken ct = default)
        {
            bool canConnect;
            try
            {
                canConnect = await _dbHealthCheck.CanConnectAsync(ct);
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
