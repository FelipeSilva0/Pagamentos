using MediatR;
using Pagamentos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.LoginUser
{
    public class LoginUsuarioCommand : IRequest<LoginUsuarioViewModel>
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
