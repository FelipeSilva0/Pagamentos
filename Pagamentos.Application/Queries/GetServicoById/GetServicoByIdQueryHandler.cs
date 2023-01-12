using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetServicoById
{
    public class GetServicoByIdQueryHandler : IRequestHandler<GetServicoByIdQuery, ServicosDetailsViewModel>
    {
        private readonly IServicoRepository _servicoRepository;
        public GetServicoByIdQueryHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<ServicosDetailsViewModel> Handle(GetServicoByIdQuery request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetDetailsByIdAsync(request.Id);

            if (servico == null) return null;

            var servicoDetailsViewModel = new ServicosDetailsViewModel(
                servico.Id,
                servico.Servico,
                servico.Valor,
                servico.IdPrestador
                );

            return servicoDetailsViewModel;
        }
    }
}
