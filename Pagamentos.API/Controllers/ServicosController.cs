using Pagamentos.Application.Commands.CreateServico;
using Pagamentos.Application.Commands.DeleteServico;
using Pagamentos.Application.Commands.UpdateServico;
using Pagamentos.Application.Queries.GetAllServicos;
using Pagamentos.Application.Queries.GetServicoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Pagamentos.API.Controllers
{
    [Route("api/servicos")]
    public class ServicosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/servicos?query=net core
        [HttpGet]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Get(string query)
        {
            var getServicosQuery = new GetServicosQuery(query);

            var servicos = await _mediator.Send(getServicosQuery);

            return Ok(servicos);
        }

        // api/servicos/2
        [HttpGet("{id}")]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetServicoByIdQuery(id);

            var servico = await _mediator.Send(query);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPost]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Post([FromBody] CreateServicoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/servicos/2
        [HttpPut("{id}")]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateServicoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/servicos/3 DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "cadastrador, administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServicoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
