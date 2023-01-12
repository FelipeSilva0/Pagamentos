using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Core.Entities
{
    public class Prestadores : BaseEntity
    {
        public Prestadores(string apelido, string nome, string cNPJ, string endereco, string numero, string complemento, string bairro, string cidade, string estado, string cEP, string telefone, string celular, string email, string categoria, string tipoPag, string tipoDoc, string banco, string agencia, string conta, string tipoPix, string pix, string favorecido, string cPF)
        {
            Apelido = apelido;
            Nome = nome;
            CNPJ = cNPJ;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Categoria = categoria;
            TipoPag = tipoPag;
            TipoDoc = tipoDoc;
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            TipoPix = tipoPix;
            Pix = pix;
            Favorecido = favorecido;
            CPF = cPF;
            Ativo = true;
        }

        public string Apelido { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Email { get; private set; }
        public string Categoria { get; private set; }
        public string TipoPag { get; private set; }
        public string TipoDoc { get; private set; }
        public string Banco { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        public string TipoPix { get; private set; }
        public string Pix { get; private set; }
        public string Favorecido { get; private set; }
        public string CPF { get; private set; }
        public bool Ativo { get; private set; }
        public List<Servicos> Servicos { get; private set; }

        public void Active()
        {
            if (Ativo == false)
            {
                Ativo = true;
            }
        }

        public void Desactive()
        {
            if (Ativo == true)
            {
                Ativo = false;
            }
        }

        public void Update(string apelido, string nome, string cNPJ, string endereco, string numero, string complemento, string bairro, string cidade, string estado, string cEP, string telefone, string celular, string email, string categoria, string tipoPag, string tipoDoc, string banco, string agencia, string conta, string tipoPix, string pix, string favorecido, string cPF, bool ativo)
        {
            Apelido = apelido;
            Nome = nome;
            CNPJ = cNPJ;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Categoria = categoria;
            TipoPag = tipoPag;
            TipoDoc = tipoDoc;
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            TipoPix = tipoPix;
            Pix = pix;
            Favorecido = favorecido;
            CPF = cPF;
            Ativo = ativo;
        }
    }
}
