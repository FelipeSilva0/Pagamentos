using FluentValidation;
using Pagamentos.Application.Commands.CreateUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pagamentos.Application.Validators
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.Senha)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");

            RuleFor(p => p.Usuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("Usuário é obrigatório!");

            RuleFor(p => p.Permissao)
                .NotEmpty()
                .NotNull()
                .WithMessage("Permissão é obrigatório!");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
