using BlazorAuth.Commands;
using BlazorAuth.Error;

namespace BlazorAuth.Services
{
    public interface IUserService
    {
        Task<ApiResult> CreateAsync(UserCommand userRequest);
        Task DeleteAsync(Guid id);
        Task<string> LoginAsync(LoginCommand loginRequest);
        Task<ApiResult> ChangePasswordAsync(Guid id, ChangePasswordCommand changePasswordRequest);
        Task<List<UserCommand>> GetUsersAsync();
    }
}
