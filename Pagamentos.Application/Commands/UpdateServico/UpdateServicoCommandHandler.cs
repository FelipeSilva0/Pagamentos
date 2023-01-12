using MediatR;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.UpdateServico
{
    public class UpdateServicoCommandHandler : IRequestHandler<UpdateServicoCommand, Unit>
    {
        private readonly IServicoRepository _servicoRepository;
        public UpdateServicoCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<Unit> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetByIdAsync(request.Id);

            servico.Update(request.Servico, request.Valor, request.IdPrestador);

            await _servicoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
