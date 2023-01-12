using Pagamentos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Repositories
{
    public interface IServicoRepository
    {
        Task<List<Servicos>> GetAllAsync();
        Task<Servicos> GetDetailsByIdAsync(int id);
        Task<Servicos> GetByIdAsync(int id);
        Task AddAsync(Servicos servico);
        Task SaveChangesAsync();
    }
}
