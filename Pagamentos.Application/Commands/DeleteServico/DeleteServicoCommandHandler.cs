using MediatR;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.DeleteServico
{
    public class DeleteServicoCommandHandler : IRequestHandler<DeleteServicoCommand, Unit>
    {
        private readonly IServicoRepository _servicoRepository;
        public DeleteServicoCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<Unit> Handle(DeleteServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetByIdAsync(request.Id);

            servico.Desactive(); // trocar para um delete

            await _servicoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
