using Pagamentos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Repositories
{
    public interface IPrestadorRepository
    {
        Task<List<Prestadores>> GetAllAsync();
        Task<Prestadores> GetDetailsByIdAsync(int id);
        Task<Prestadores> GetByIdAsync(int id);
        Task AddAsync(Prestadores prestador);
        Task SaveChangesAsync();
    }
}
