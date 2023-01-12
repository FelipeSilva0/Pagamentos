using MediatR;
using System;
using Pagamentos.Core.Entities;
using Pagamentos.Infrastructure.Persistence;
using System.Threading.Tasks;
using System.Threading;
using Pagamentos.Core.Repositories;

namespace Pagamentos.Application.Commands.CreateServico
{
    public class CreateServicoCommandHandler : IRequestHandler<CreateServicoCommand, int>
    {
        private readonly IServicoRepository _servicoRepository;
        public CreateServicoCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<int> Handle(CreateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Servicos(request.Servico, request.Valor, request.IdPrestador);

            await _servicoRepository.AddAsync(servico);

            return servico.Id;
        }
    }
}
