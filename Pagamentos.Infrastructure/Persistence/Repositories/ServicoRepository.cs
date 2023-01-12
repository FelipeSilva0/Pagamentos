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
    public class ServicoRepository : IServicoRepository
    {
        private readonly PagamentosDbContext _dbContext;
        private readonly string _connectionString;
        public ServicoRepository(PagamentosDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("Pagamentos");
        }

        public async Task<List<Servicos>> GetAllAsync()
        {
            return await _dbContext.Servicos.ToListAsync();
        }

        public async Task<Servicos> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Servicos
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Servicos servico)
        {
            await _dbContext.Servicos.AddAsync(servico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Servicos> GetByIdAsync(int id)
        {
            return await _dbContext.Servicos.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
