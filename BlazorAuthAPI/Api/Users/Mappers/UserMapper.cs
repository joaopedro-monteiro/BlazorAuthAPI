using BlazorAuthAPI.Api.Users.Dtos;
using BlazorAuthAPI.Core.Models;

namespace BlazorAuthAPI.Api.Users.Mappers
{
    public class UserMapper : IUserMapper
    {
        public User ToModel(UserRequest userRequest)
        {
            return new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest.Password,
                Cpf = userRequest.Cpf,
                Role = userRequest.Role
            };
        }
    }
}
