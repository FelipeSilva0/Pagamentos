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

namespace Pagamentos.Application.Queries.GetAllPrestadores
{
    public class GetPrestadoresQueryHandler : IRequestHandler<GetPrestadoresQuery, List<PrestadoresViewModel>>
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public GetPrestadoresQueryHandler(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<List<PrestadoresViewModel>> Handle(GetPrestadoresQuery request, CancellationToken cancellationToken)
        {
            var prestadores = await _prestadorRepository.GetAllAsync();

            var prestadoresViewModel = prestadores
                .Select(p => new PrestadoresViewModel(p.Id, p.Apelido, p.CNPJ, p.Estado, p.CEP, p.Categoria, p.Banco, p.Ativo))
                .ToList();

            return prestadoresViewModel;
        }
    }
}
