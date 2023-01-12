using MediatR;
using Microsoft.EntityFrameworkCore;
using Pagamentos.Application.ViewModels;
using Pagamentos.Core.Repositories;
using Pagamentos.Infrastructure.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Queries.GetUsuario
{
    public class GetUserQueryHandler : IRequestHandler<GetUsuarioQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _userRepository;
        public GetUserQueryHandler(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsuarioViewModel> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }

            return new UsuarioViewModel(user.Usuario, user.Permissao);
        }
    }
}
