using MediatR;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.DeletePrestador
{
    public class DeletePrestadorCommandHandler : IRequestHandler<DeletePrestadorCommand, Unit>
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public DeletePrestadorCommandHandler(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<Unit> Handle(DeletePrestadorCommand request, CancellationToken cancellationToken)
        {
            var prestador = await _prestadorRepository.GetByIdAsync(request.Id);

            prestador.Desactive(); // trocar para um delete

            await _prestadorRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
