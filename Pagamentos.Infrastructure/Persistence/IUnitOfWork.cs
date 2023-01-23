using Pagamentos.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IPrestadorRepository Prestadores { get; }
        IServicoRepository Servicos { get; }
        IUsuarioRepository Usuarios { get; }
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
    }
}
