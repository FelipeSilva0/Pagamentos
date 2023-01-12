using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string usuario, string permissao)
        {
            Usuario = usuario;
            Permissao = permissao;
        }

        public string Usuario { get; private set; }
        public string Permissao { get; private set; }
    }
}
