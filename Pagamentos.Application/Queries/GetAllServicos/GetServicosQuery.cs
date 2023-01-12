using MediatR;
using Pagamentos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetAllServicos
{
    public class GetServicosQuery : IRequest<List<ServicosViewModel>>
    {
        public GetServicosQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
