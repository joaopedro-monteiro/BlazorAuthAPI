using BlazorAuthAPI.Core.User.Dtos;

namespace BlazorAuthAPI.Core.User.Mappers
{
    public interface IUserMapper
    {
        Entities.User ToModel(UserRequest userRequest);
    }
}
