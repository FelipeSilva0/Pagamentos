using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.ViewModels
{
    public class PrestadoresViewModel
    {
        public PrestadoresViewModel(int id, string apelido, string cNPJ, string estado, string cEP, string categoria, string banco, bool ativo)
        {
            Id = id;
            Apelido = apelido;
            CNPJ = cNPJ;
            Estado = estado;
            CEP = cEP;
            Categoria = categoria;
            Banco = banco;
            Ativo = ativo;
        }

        public int Id { get; private set; }
        public string Apelido { get; private set; }
        public string CNPJ { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public string Categoria { get; private set; }
        public string Banco { get; private set; }
        public bool Ativo { get; private set; }
    }
}
