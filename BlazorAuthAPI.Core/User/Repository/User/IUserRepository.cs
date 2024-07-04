using BlazorAuth.Shared.Interface;

namespace BlazorAuthAPI.Core.User.Repository.User
{
    public interface IUserRepository : ICrudRepository<Entities.User, Guid>
    {
    }
}
