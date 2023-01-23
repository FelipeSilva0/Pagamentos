using Pagamentos.Core.Entities;
using Pagamentos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Repositories
{
    public interface IPrestadorRepository
    {
        Task<PaginationResult<Prestadores>> GetAllAsync(string query, int page = 1);
        Task<Prestadores> GetDetailsByIdAsync(int id);
        Task<Prestadores> GetByIdAsync(int id);
        Task AddAsync(Prestadores prestador);
        Task UpdateAsync(Prestadores prestador);
        Task SaveChangesAsync();
    }
}
