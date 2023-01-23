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
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly PagamentosDbContext _dbContext;
        private const int PAGE_SIZE = 2;
        public PrestadorRepository(PagamentosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<Prestadores>> GetAllAsync(string query, int page)
        {
            // Filtro
            IQueryable<Prestadores> prestadores = _dbContext.Prestadores;

            if (!string.IsNullOrWhiteSpace(query))
            {
                prestadores = prestadores
                    .Where(p =>
                        p.Apelido.Contains(query) ||
                        p.Nome.Contains(query) ||
                        p.Estado.Contains(query) ||
                        p.Categoria.Contains(query) ||
                        p.Ativo.ToString().Contains(query));
            }

            return await prestadores.GetPaged<Prestadores>(page, PAGE_SIZE);
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
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Prestadores> GetByIdAsync(int id)
        {
            return await _dbContext.Prestadores.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Prestadores prestador)
        {
            _dbContext.Update(prestador);
            await _dbContext.SaveChangesAsync();
        }
    }
}
