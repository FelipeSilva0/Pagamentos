using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Models;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetAllServicos
{
    public class GetServicosQueryHandler : IRequestHandler<GetServicosQuery, PaginationResult<ServicosViewModel>>
    {
        private readonly IServicoRepository _servicoRepository;
        public GetServicosQueryHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<PaginationResult<ServicosViewModel>> Handle(GetServicosQuery request, CancellationToken cancellationToken)
        {
            var servicosPaginationResult = await _servicoRepository.GetAllAsync(request.Query, request.Page);

            var servicosViewModel = servicosPaginationResult
                .Data
                .Select(p => new ServicosViewModel(p.Id, p.Servico, p.Valor, p.IdPrestador))
                .ToList();

            var paginationResult = new PaginationResult<ServicosViewModel>(
               servicosPaginationResult.Page,
               servicosPaginationResult.TotalPages,
               servicosPaginationResult.PageSize,
               servicosPaginationResult.ItemsCount,
               servicosViewModel
            );

            return paginationResult;
        }
    }
}
