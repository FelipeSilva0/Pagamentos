using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.ViewModels
{
    public class ServicosDetailsViewModel
    {
        public ServicosDetailsViewModel(int id, string servico, decimal valor, int idPrestador)
        {
            Id = id;
            Servico = servico;
            Valor = valor;
            IdPrestador = idPrestador;
        }

        public int Id { get; private set; }
        public string Servico { get; set; }
        public decimal Valor { get; set; }
        public int IdPrestador { get; set; }
    }
}
