using Pagamentos.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.API.Health
{
    public class DatabaseHealthCheck : IDatabaseHealthCheck
    {
        private readonly PagamentosDbContext _context;

        public DatabaseHealthCheck(PagamentosDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CanConnectAsync(CancellationToken ct = default)
        {
            return await _context.Database.CanConnectAsync(ct);
        }
    }
}
