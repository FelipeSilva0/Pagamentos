using Pagamentos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> GetByIdAsync(int id);
        Task<Usuarios> GetUserByUserAndPasswordAsync(string usuario, string passwordHash);

    }
}
