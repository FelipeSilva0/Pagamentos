using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Entities
{
    public class Servicos : BaseEntity
    {
        public Servicos(string servico, decimal valor, int idPrestador)
        {
            Servico = servico;
            Valor = valor;
            IdPrestador = idPrestador;
        }

        public string Servico { get; private set; }
        public decimal Valor { get; private set; }
        public int IdPrestador { get; private set; }
        public Prestadores Prestadores { get; private set; }

        public void Update(string servico, decimal valor, int idPrestador)
        {
            Servico = servico;
            Valor = valor;
            IdPrestador = idPrestador;
        }


        public void Desactive()
        {
        }
    }
}
