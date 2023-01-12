using Microsoft.EntityFrameworkCore;
using Pagamentos.Core.Entities;
using Pagamentos.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PagamentosDbContext _dbContext;
        public UsuarioRepository(PagamentosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuarios> GetByIdAsync(int id)
        {
            return await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuarios> GetUserByUserAndPasswordAsync(string usuario, string passwordHash)
        {
            return await _dbContext
                .Usuarios
                .SingleOrDefaultAsync(u => u.Usuario == usuario && u.Senha == passwordHash);
        }
    }
}