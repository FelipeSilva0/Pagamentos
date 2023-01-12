using Pagamentos.Application.Commands.CreatePrestador;
using Pagamentos.Application.Commands.DeletePrestador;
using Pagamentos.Application.Commands.UpdatePrestador;
using Pagamentos.Application.Queries.GetAllPrestadores;
using Pagamentos.Application.Queries.GetPrestadorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Pagamentos.API.Controllers
{
    [Route("api/prestadores")]
    public class PrestadoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PrestadoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/prestadores?query=net core
        [HttpGet]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Get(string query)
        {
            var getPrestadoresQuery = new GetPrestadoresQuery(query);

            var prestadores = await _mediator.Send(getPrestadoresQuery);

            return Ok(prestadores);
        }

        // api/prestadores/2
        [HttpGet("{id}")]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPrestadorByIdQuery(id);

            var prestador = await _mediator.Send(query);

            if (prestador == null)
            {
                return NotFound();
            }

            return Ok(prestador);
        }

        [HttpPost]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Post([FromBody] CreatePrestadorCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/prestadores/2
        [HttpPut("{id}")]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePrestadorCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/prestadores/3 DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePrestadorCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
