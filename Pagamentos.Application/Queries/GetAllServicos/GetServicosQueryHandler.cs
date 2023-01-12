using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetAllServicos
{
    public class GetServicosQueryHandler : IRequestHandler<GetServicosQuery, List<ServicosViewModel>>
    {
        private readonly IServicoRepository _servicoRepository;
        public GetServicosQueryHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<List<ServicosViewModel>> Handle(GetServicosQuery request, CancellationToken cancellationToken)
        {
            var servicos = await _servicoRepository.GetAllAsync();

            var servicosViewModel = servicos
                .Select(p => new ServicosViewModel(p.Id, p.Servico, p.Valor, p.IdPrestador))
                .ToList();

            return servicosViewModel;
        }
    }
}
