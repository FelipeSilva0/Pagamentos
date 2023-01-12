using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Enums
{
    public enum SolicitacaoStatusEnum
    {
        Solicitado = 0,
        Autorizado = 1,
        Pago = 2,
        Finalizado= 3,
        Cancelado = 4,
        Pendente = 5
    }
}
