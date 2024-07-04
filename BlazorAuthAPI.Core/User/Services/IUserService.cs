using BlazorAuthAPI.Core.User.Commands;

namespace BlazorAuthAPI.Core.User.Services
{
    public interface IUserService
    {
        Task<Entities.User> CreateAsync(AddNewUserCommand userRequest);
        Task DeleteAsync(Guid id);
        Task<ICollection<Entities.User>> FindAllAsync();
    }
}
