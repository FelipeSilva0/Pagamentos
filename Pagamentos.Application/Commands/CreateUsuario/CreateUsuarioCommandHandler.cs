using Pagamentos.Core.Entities;
using Pagamentos.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pagamentos.Core.Services;

namespace Pagamentos.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly PagamentosDbContext _dbContext;
        private readonly IAuthService _authService;

        public CreateUsuarioCommandHandler(PagamentosDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;

        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var user = new Usuarios(request.Usuario, passwordHash, request.Email, request.Permissao);

            await _dbContext.Usuarios.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
