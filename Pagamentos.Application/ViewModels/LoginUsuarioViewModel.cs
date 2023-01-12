namespace Pagamentos.Application.ViewModels
{
    public class LoginUsuarioViewModel
    {
        public LoginUsuarioViewModel(string usuario, string token)
        {
            Usuario = usuario;
            Token = token;
        }

        public string Usuario { get; private set; }
        public string Token { get; private set; }
    }
}
