namespace Pagamentos.API.Models
{
    public record DatabaseHealthInfo(bool CanConnect);

    public record HealthDetailsResponse(
        string Status,
        string Application,
        string Environment,
        string TimestampUtc,
        string Version,
        DatabaseHealthInfo Database
    );
}
