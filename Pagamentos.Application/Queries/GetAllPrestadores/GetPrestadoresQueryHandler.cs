using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Models;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetAllPrestadores
{
    public class GetPrestadoresQueryHandler : IRequestHandler<GetPrestadoresQuery, PaginationResult<PrestadoresViewModel>>
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public GetPrestadoresQueryHandler(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<PaginationResult<PrestadoresViewModel>> Handle(GetPrestadoresQuery request, CancellationToken cancellationToken)
        {
            var prestadoresPaginationResult = await _prestadorRepository.GetAllAsync(request.Query, request.Page);

            var prestadoresViewModel = prestadoresPaginationResult
                .Data
                .Select(p => new PrestadoresViewModel(p.Id, p.Apelido, p.CNPJ, p.Estado, p.CEP, p.Categoria, p.Banco, p.Ativo))
                .ToList();

            var paginationResult = new PaginationResult<PrestadoresViewModel>(
               prestadoresPaginationResult.Page,
               prestadoresPaginationResult.TotalPages,
               prestadoresPaginationResult.PageSize,
               prestadoresPaginationResult.ItemsCount,
               prestadoresViewModel
            );

            return paginationResult;
        }
    }
}
