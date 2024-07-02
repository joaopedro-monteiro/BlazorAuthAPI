using BlazorAuthAPI.Api.Users.Dtos;
using BlazorAuthAPI.Core.Models;

namespace BlazorAuthAPI.Api.Users.Services
{
    public interface IUserService
    {
        User Create(UserRequest userRequest);
        void Delete(Guid id);
        ICollection<User> FindAll();
    }
}
