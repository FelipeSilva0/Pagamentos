using MediatR;
using System;

namespace Pagamentos.Application.Commands.UpdateServico
{
    public class UpdateServicoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Servico { get; set; }
        public decimal Valor { get; set; }
        public int IdPrestador { get; set; }
    }
}
