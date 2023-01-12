using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.ViewModels
{
    public class ServicosViewModel
    {
        public ServicosViewModel(int id, string servico, decimal valor, int prestadoresId)
        {
            Id = id;
            Servico = servico;
            Valor = valor;
            PrestadoresId = prestadoresId;
        }

        public int Id { get; private set; }
        public string Servico { get; set; }
        public decimal Valor { get; set; }
        public int PrestadoresId { get; set; }
    }
}
