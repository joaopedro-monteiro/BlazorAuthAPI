using AutoMapper;
using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.Results;
using BlazorAuthAPI.Core.Shared.Helpers;
using BlazorAuthAPI.Core.User.Commands;
using BlazorAuthAPI.Core.User.QueryCommand;
using BlazorAuthAPI.Core.User.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorAuthAPI.Core.User.Services
{
    public class UserService(IMapper mapper, AppDbContext context, IValidator<AddNewUserCommand> addNewUserValidator, IValidator<Entities.User> userValidator, IValidator<LoginCommand> loginValidator, IValidator<ChangePasswordCommand> changePasswordValidator) : IUserService
    {
        public async Task ChangePasswordAsync(Guid id, ChangePasswordCommand changePasswordRequest)
        {
            await changePasswordValidator.ValidateAndThrowAsync(changePasswordRequest);

            var user = await context.Users.FindAsync(id);

            if (user == null)
                throw new Exception("User not found");

            if (!PasswordHelper.VerifyPassword(changePasswordRequest.CurrentPassword, user.PasswordHashed))
                throw new Exception("Senha atual inválida");

            user.PasswordHashed = PasswordHelper.HashPassword(changePasswordRequest.NewPassword!);

            context.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task<Entities.User> CreateAsync(AddNewUserCommand userRequest)
        {
            await addNewUserValidator.ValidateAndThrowAsync(userRequest);

            var user = mapper.Map<Entities.User>(userRequest);

            await userValidator.ValidateAndThrowAsync(user);

            user.PasswordHashed = PasswordHelper.HashPassword(user.PasswordHashed!);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null) throw new Exception("User not found");

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<LoginResult> LoginAsync(LoginCommand loginRequest)
        {
            await loginValidator.ValidateAndThrowAsync(loginRequest);
            var user = await context.Users.FirstAsync(w => w.Email == loginRequest.Email);

            return new LoginResult(user);
        }
    }
}
