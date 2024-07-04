using BlazorAuthAPI.Core.User.Dtos;

namespace BlazorAuthAPI.Core.User.Services
{
    public interface IUserService
    {
        Task<Entities.User> Create(UserRequest userRequest);
        void Delete(Guid id);
        Task<ICollection<Entities.User>> FindAll();
    }
}
