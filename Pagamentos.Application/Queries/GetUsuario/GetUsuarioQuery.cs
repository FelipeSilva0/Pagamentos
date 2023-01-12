using MediatR;
using Pagamentos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetUsuario
{
    public class GetUsuarioQuery : IRequest<UsuarioViewModel>
    {
        public GetUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
