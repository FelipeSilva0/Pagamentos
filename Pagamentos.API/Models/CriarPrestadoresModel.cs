namespace Pagamentos.API.Models
{
    public class CriarPrestadoresModel
    {
        public int Id { get; set; }

        public string Apelido { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string CEP { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Categoria { get; set; }

        public string TipoPag { get; set; }

        public string TipoDoc { get; set; }

        public string Banco { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }

        public string TipoPix { get; set; }

        public string Pix { get; set; }

        public string Favorecido { get; set; }

        public string CPF { get; set; }

        public bool Ativo { get; set; }
    }
}
