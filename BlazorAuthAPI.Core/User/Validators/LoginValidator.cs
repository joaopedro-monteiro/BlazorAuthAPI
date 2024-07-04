using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.Shared.Helpers;
using BlazorAuthAPI.Core.User.Commands;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.User.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        private readonly AppDbContext _context;

        public LoginValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório")
                .EmailAddress()
                .WithMessage("E-mail inválido");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Senha é obrigatória");

            RuleFor(r => r.Password)
                .MustAsync(PasswordCheckAsync)
                .WithMessage("E-mail e/ou senha inválido");
        }

        private async Task<bool> PasswordCheckAsync(LoginCommand command, string? password, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

            if (user == null)
                return false;

            return PasswordHelper.VerifyPassword(password, user.PasswordHashed);
        }
    }
}
