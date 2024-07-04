using BlazorAuthAPI.Core.Results;
using BlazorAuthAPI.Core.User.Commands;

namespace BlazorAuthAPI.Core.User.Services
{
    public interface IUserService
    {
        Task<Entities.User> CreateAsync(AddNewUserCommand userRequest);
        Task DeleteAsync(Guid id);
        Task<LoginResult> LoginAsync(LoginCommand loginRequest);
        Task ChangePasswordAsync(Guid id, ChangePasswordCommand changePasswordRequest);
    }
}
