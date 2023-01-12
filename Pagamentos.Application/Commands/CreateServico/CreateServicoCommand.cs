using MediatR;
using System;

namespace Pagamentos.Application.Commands.CreateServico
{
    public class CreateServicoCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Servico { get; set; }

        public decimal Valor { get; set; }

        public int IdPrestador { get; set; }
    }
}
