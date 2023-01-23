using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pagamentos.Core.Entities;
using Pagamentos.Core.Models;
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
        private const int PAGE_SIZE = 2;
        public ServicoRepository(PagamentosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<Servicos>> GetAllAsync(string query, int page)
        {
            // Filtro
            IQueryable<Servicos> servicos = _dbContext.Servicos;

            if (!string.IsNullOrWhiteSpace(query))
            {
                servicos = servicos
                    .Where(p =>
                        p.Servico.Contains(query) ||
                        p.IdPrestador.ToString().Contains(query) ||
                        p.Valor.ToString().Contains(query));
            }

            return await servicos.GetPaged<Servicos>(page, PAGE_SIZE);
        }

        public async Task<Servicos> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Servicos
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Servicos servico)
        {
            await _dbContext.Servicos.AddAsync(servico);
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
