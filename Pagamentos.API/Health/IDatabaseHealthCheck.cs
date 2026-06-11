using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.API.Health
{
    public interface IDatabaseHealthCheck
    {
        Task<bool> CanConnectAsync(CancellationToken ct = default);
    }
}
