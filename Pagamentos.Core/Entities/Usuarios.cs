using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Entities
{
    public class Usuarios : BaseEntity
    {
        public Usuarios(string usuario, string senha, string email, string permissao)
        {
            Usuario = usuario;
            Senha = senha;
            Email = email;
            Permissao = permissao;
            Ativo = true;

            Prestadores = new List<Prestadores>();
            Servicos = new List<Servicos>();
        }

        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string Permissao { get; private set; }
        public bool Ativo { get; private set; }

        public List<Prestadores> Prestadores { get; private set; }
        public List<Servicos> Servicos { get; private set; }

    }
}
