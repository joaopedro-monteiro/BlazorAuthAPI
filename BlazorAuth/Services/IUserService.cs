using BlazorAuth.Models;
using BlazorAuth.Shared.Interface;

namespace BlazorAuth.Services
{
    public interface IUserService : ICrudRepository<User, Guid>
    {
    }
}
