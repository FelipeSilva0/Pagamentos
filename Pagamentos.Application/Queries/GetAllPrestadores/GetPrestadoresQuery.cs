using MediatR;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetAllPrestadores
{
    public class GetPrestadoresQuery : IRequest<PaginationResult<PrestadoresViewModel>>
    {
        public string Query { get; set; }
        public int Page { get; set; } = 1;
    }
}
