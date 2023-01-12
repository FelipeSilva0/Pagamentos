using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string usuario, string permissao);
        string ComputeSha256Hash(string password);
    }
}
