using BlazorAuthAPI.Core.Shared.Helpers;
using BlazorAuthAPI.Core.User.Commands;
using FluentValidation;

namespace BlazorAuthAPI.Core.User.Validators;
public class AddNewUserValidator : AbstractValidator<AddNewUserCommand>
{
    public AddNewUserValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("O nome é obrigatório")
            .Length(1, 200)
            .WithMessage("O nome deve possuir até 200 caracteres");

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("O e-mail é obrigatório")
            .Length(1, 200)
            .WithMessage("O e-mail deve possuir até 200 caracteres")
            .EmailAddress()
            .WithMessage("Informe um e-mail válido");

        RuleFor(r => r.PasswordHashed)
            .NotEmpty()
            .WithMessage("Informe a nova senha")
            .Must(PasswordHelper.IsValid)
            .WithMessage("A senha deve possuir ao menos 8 caracteres, uma letra maiúscula e um número");

        RuleFor(r => r.Cpf)
            .Must(CpfHelper.IsValid)
            .WithMessage("CPF inválido");

        RuleFor(r => r.Role)
            .IsInEnum()
            .WithMessage("Selecione um perfil válido");
    }
}
