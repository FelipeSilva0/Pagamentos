using FluentValidation;
using Pagamentos.Application.Commands.CreatePrestador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pagamentos.Application.Validators
{
    public class CreatePrestadorCommandValidator : AbstractValidator<CreatePrestadorCommand>
    {
        public CreatePrestadorCommandValidator()
        {
            RuleFor(p => p.Apelido)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Apelido é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Apelido não pode ser nulo.");

            RuleFor(p => p.Nome)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Nome é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Nome não pode ser nulo.");

            RuleFor(p => p.CNPJ)
                .MaximumLength(14)
                .WithMessage("Tamanho máximo do CNPJ é de 14 caracteres.")
                .Must(ValidNumbers)
                .WithMessage("Somente números.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O CNPJ não pode ser nulo.");

            RuleFor(p => p.Endereco)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Endereco é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Endereco não pode ser nulo.");

            RuleFor(p => p.Numero)
                .MaximumLength(20)
                .WithMessage("Tamanho máximo do Número é de 20 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Número não pode ser nulo.");

            RuleFor(p => p.Complemento)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Complemento é de 255 caracteres.");

            RuleFor(p => p.Bairro)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Bairro é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Bairro não pode ser nulo.");

            RuleFor(p => p.Cidade)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo da Cidade é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("A Cidade não pode ser nulo.");

            RuleFor(p => p.Estado)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Estado é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Estado não pode ser nulo.");

            RuleFor(p => p.CEP)
                .MaximumLength(8)
                .WithMessage("Tamanho máximo do CEP é de 8 caracteres.")
                .Must(ValidNumbers)
                .WithMessage("Somente números.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O CEP não pode ser nulo.");

            RuleFor(p => p.Telefone)
                .Must(ValidNumbers)
                .WithMessage("Somente números.")
                .MaximumLength(11)
                .WithMessage("Tamanho máximo do Telefone é de 11 caracteres.");

            RuleFor(p => p.Celular)
                .Must(ValidNumbers)
                .WithMessage("Somente números.")
                .MaximumLength(12)
                .WithMessage("Tamanho máximo do Celular é de 12 caracteres.");

            RuleFor(p => p.Email)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Email é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Email não pode ser nulo.");

            RuleFor(p => p.Categoria)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo da Categoria é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O Categoria não pode ser nulo.");

            RuleFor(p => p.TipoPag)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do tipo de pagamento é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O tipo de pagamento não pode ser nulo.");

            RuleFor(p => p.TipoDoc)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do tipo de documento é de 255 caracteres.");

            RuleFor(p => p.Banco)
                .MaximumLength(50)
                .WithMessage("Tamanho máximo do Banco é de 50 caracteres.");
            //.NotEmpty()
            //.NotNull()
            //.WithMessage("O Banco não pode ser nulo.");

            RuleFor(p => p.Agencia)
                .MaximumLength(50)
                .WithMessage("Tamanho máximo da Agência é de 50 caracteres.");
            //.NotEmpty()
            //.NotNull()
            //.WithMessage("A Agência não pode ser nulo.");

            RuleFor(p => p.Conta)
                .MaximumLength(50)
                .WithMessage("Tamanho máximo da Conta é de 50 caracteres.");
            //.NotEmpty()
            //.NotNull()
            //.WithMessage("A Conta não pode ser nulo.");

            RuleFor(p => p.TipoPix)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do tipo de pix é de 255 caracteres.");
            //.NotEmpty()
            //.NotNull()
            //.WithMessage("O tipo de pix não pode ser nulo.");

            RuleFor(p => p.Pix)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Pix é de 255 caracteres.");
            //.NotEmpty()
            //.NotNull()
            //.WithMessage("O Pix não pode ser nulo.");

            RuleFor(p => p.Favorecido)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do nome do favorecido é de 255 caracteres.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome do favorecido não pode ser nulo.");

            RuleFor(p => p.CPF)
                .MaximumLength(12)
                .WithMessage("Tamanho máximo do CPF é de 12 caracteres.")
                .Must(ValidNumbers)
                .WithMessage("Somente números.")
                .NotEmpty()
                .NotNull()
                .WithMessage("O CPF não pode ser nulo.");

            RuleFor(p => p.Ativo)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário um status para o prestador.");
        }

        public bool ValidNumbers(string number)
        {
            var regex = new Regex(@"[^\d]");

            return regex.IsMatch(number);
        }
    }
}
