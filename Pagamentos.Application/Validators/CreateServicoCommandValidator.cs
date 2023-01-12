using FluentValidation;
using Pagamentos.Application.Commands.CreateServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Application.Validators
{
    public class CreateServicoCommandValidator : AbstractValidator<CreateServicoCommand>
    {
        public CreateServicoCommandValidator()
        {
            RuleFor(p => p.Servico)
                .MaximumLength(255)
                .NotEmpty()
                .NotNull()
                .WithMessage("Tamanho máximo do serviço é de 255 caracteres.");

            RuleFor(p => p.Valor)
                .NotNull()
                .WithMessage("O valor do serviço não pode ser nulo.");

            RuleFor(p => p.IdPrestador)
                .NotNull()
                .NotEmpty()
                .WithMessage("É necessário escolher um prestador.");
        }
    }
}
