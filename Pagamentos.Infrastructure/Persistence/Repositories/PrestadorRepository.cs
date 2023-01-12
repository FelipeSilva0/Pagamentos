using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pagamentos.Core.Entities;
using Pagamentos.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Infrastructure.Persistence.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly PagamentosDbContext _dbContext;
        private readonly string _connectionString;
        public PrestadorRepository(PagamentosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("Pagamentos");
        }

        public async Task<List<Prestadores>> GetAllAsync()
        {
            return await _dbContext.Prestadores.ToListAsync();
        }

        public async Task<Prestadores> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Prestadores
                .Include(s => s.Servicos)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Prestadores prestador)
        {
            await _dbContext.Prestadores.AddAsync(prestador);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Prestadores> GetByIdAsync(int id)
        {
            return await _dbContext.Prestadores.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
