using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.Shared.Helpers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.User.Validators
{
    public class UserValidator : AbstractValidator<Entities.User>
    {
        private readonly AppDbContext _context;

        public UserValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("Informe o Id");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório")
                .Length(1, 100)
                .WithMessage("O nome deve possuir até 200 caracteres");

            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório")
                .Length(1, 100)
                .WithMessage("O e-mail deve possuir até 200 caracteres")
                .EmailAddress()
                .WithMessage("Informe um e-mail válido")
                .MustAsync(EmailUnicoAsync)
                .WithMessage("O e-mail deve ser único");

            RuleFor(r => r.PasswordHashed)
                .NotEmpty()
                .WithMessage("Informe a senha");

            RuleFor(r => r.Cpf)
                .Must(CpfHelper.IsValid)
                .WithMessage("CPF inválido")
                .MustAsync(CpfUnicoAsync)
                .WithMessage("O CPF deve ser único");

            RuleFor(r => r.Role)
                .IsInEnum()
                .WithMessage("Selecione um perfil válido");
        }

        private async Task<bool> EmailUnicoAsync(Entities.User user, string? email, CancellationToken cancellationToken)
        {
            return !await _context.Users.AnyAsync(u => u.Email == email && u.Id != user.Id, cancellationToken);
        }

        private async Task<bool> CpfUnicoAsync(Entities.User user, string? cpf, CancellationToken cancellationToken)
        {
            return !await _context.Users.AnyAsync(u => u.Cpf == cpf && u.Id != user.Id, cancellationToken);
        }
    }
}
