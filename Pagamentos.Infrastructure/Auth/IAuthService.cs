namespace Pagamentos.Core.Services
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
        string GenerateJwtToken(string usuario, string permissao);
    }
}
