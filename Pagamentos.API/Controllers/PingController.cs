using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.API.Models;

namespace Pagamentos.API.Controllers
{
    [ApiController]
    [Route("ping")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(new PongResponse("pong"));
        }
    }
}
