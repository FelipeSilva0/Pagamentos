using Pagamentos.Application.Commands.CreateUsuario;
using Pagamentos.Application.Queries.GetUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Pagamentos.Application.Commands.LoginUser;

namespace Pagamentos.API.Controllers
{
    [Route("api/usuarios")]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUsuarioQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // api/users
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/users/1/login
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command)
        {
            var loginUsuarioviewModel = await _mediator.Send(command);

            if (loginUsuarioviewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUsuarioviewModel);
        }
    }
}
