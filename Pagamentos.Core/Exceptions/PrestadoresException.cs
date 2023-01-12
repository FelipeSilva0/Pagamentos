using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Exceptions
{
    public class PrestadoresException : Exception
    {
        public PrestadoresException() : base("Houve um erro ao criar o Prestador.")
        {
        }
    }
}
