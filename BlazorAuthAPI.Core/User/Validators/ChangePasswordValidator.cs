using BlazorAuthAPI.Core.Shared.Helpers;
using BlazorAuthAPI.Core.User.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuthAPI.Core.User.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(r => r.CurrentPassword)
                .NotEmpty()
                .WithMessage("Informe a senha atual");

            RuleFor(r => r.NewPassword)
                .NotEmpty()
                .WithMessage("Informe a nova senha")
                .Must(PasswordHelper.IsValid)
                .WithMessage("Senha inválida");
        }
    }
}
