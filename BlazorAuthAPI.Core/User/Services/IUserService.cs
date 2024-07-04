using BlazorAuthAPI.Core.User.Commands;

namespace BlazorAuthAPI.Core.User.Services
{
    public interface IUserService
    {
        Task<Entities.User> Create(AddNewUserCommand userRequest);
        void Delete(Guid id);
        Task<ICollection<Entities.User>> FindAll();
    }
}
