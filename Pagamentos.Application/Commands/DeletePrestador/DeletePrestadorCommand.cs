using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.DeletePrestador
{
    public class DeletePrestadorCommand : IRequest<Unit>
    {
        public DeletePrestadorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
