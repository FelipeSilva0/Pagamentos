namespace Pagamentos.API.Models
{
    public class CriarServicos
    {

        public int Id { get; set; }

        public string Servico { get; set; }

        public decimal Valor { get; set; }

        public int PrestadoresId { get; set; }

        public virtual CriarPrestadoresModel Prestadores { get; set; }
    }
}
