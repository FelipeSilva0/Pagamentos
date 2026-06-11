namespace Pagamentos.API.Health
{
    public interface IDatabaseHealthCheck
    {
        bool CanConnect();
    }
}
