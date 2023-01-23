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
        private readonly IUnitOfWork _unitOfWork;
        public CreateServicoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new Servicos(request.Servico, request.Valor, request.IdPrestador);

            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.Servicos.AddAsync(servico);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return servico.Id;
        }
    }
}
