using BlazorAuthAPI.Core.User.Commands;

namespace BlazorAuthAPI.Core.User.Mappers
{
    public interface IUserMapper
    {
        Entities.User ToModel(AddNewUserCommand userRequest);
    }
}
