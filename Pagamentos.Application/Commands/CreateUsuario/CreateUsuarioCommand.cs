using MediatR;
using System;

namespace Pagamentos.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Permissao { get; set; }
        public bool Ativo { get; set; }
    }
}
