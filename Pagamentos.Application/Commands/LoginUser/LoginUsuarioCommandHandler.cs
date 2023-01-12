using MediatR;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Repositories;
using Pagamentos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Commands.LoginUser
{
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, LoginUsuarioViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _userRepository;
        public LoginUsuarioCommandHandler(IAuthService authService, IUsuarioRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUsuarioViewModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            // Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
            var user = await _userRepository.GetUserByUserAndPasswordAsync(request.Usuario, passwordHash);

            // Se nao existir, erro no login
            if (user == null)
            {
                return null;
            }

            // Se existir, gero o token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Usuario, user.Permissao);

            return new LoginUsuarioViewModel(user.Usuario, token);
        }
    }
}
