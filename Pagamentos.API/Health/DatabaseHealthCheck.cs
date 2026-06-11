using Pagamentos.Infrastructure.Persistence;

namespace Pagamentos.API.Health
{
    public class DatabaseHealthCheck : IDatabaseHealthCheck
    {
        private readonly PagamentosDbContext _context;

        public DatabaseHealthCheck(PagamentosDbContext context)
        {
            _context = context;
        }

        public bool CanConnect()
        {
            return _context.Database.CanConnect();
        }
    }
}
