using MediatR;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Models;
using System.Collections.Generic;

namespace Pagamentos.Application.Queries.GetAllServicos
{
    public class GetServicosQuery : IRequest<PaginationResult<ServicosViewModel>>
    {
        public string Query { get; set; }
        public int Page { get; set; } = 1;
    }
}
