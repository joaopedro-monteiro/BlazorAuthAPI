using BlazorAuthAPI.Api.Users.Dtos;
using BlazorAuthAPI.Core.Models;

namespace BlazorAuthAPI.Api.Users.Mappers
{
    public interface IUserMapper
    {
        User ToModel(UserRequest userRequest);
    }
}
