using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pagamentos.API.Controllers
{
    [Route("ping")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(new { message = "pong" });
        }
    }
}
