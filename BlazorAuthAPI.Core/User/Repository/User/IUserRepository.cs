using BlazorAuth.Shared.Interface;

namespace BlazorAuthAPI.Core.Repository.User
{
    public interface IUserRepository : ICrudRepository<Models.User, Guid>
    {
    }
}
