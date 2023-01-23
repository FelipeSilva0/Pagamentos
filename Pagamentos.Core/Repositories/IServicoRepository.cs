using Pagamentos.Core.Entities;
using Pagamentos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Repositories
{
    public interface IServicoRepository
    {
        Task<PaginationResult<Servicos>> GetAllAsync(string query, int page = 1);
        Task<Servicos> GetDetailsByIdAsync(int id);
        Task<Servicos> GetByIdAsync(int id);
        Task AddAsync(Servicos servico);
        Task SaveChangesAsync();
    }
}
