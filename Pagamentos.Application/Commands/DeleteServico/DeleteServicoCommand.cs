using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.DeleteServico
{
    public class DeleteServicoCommand : IRequest<Unit>
    {
        public DeleteServicoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
