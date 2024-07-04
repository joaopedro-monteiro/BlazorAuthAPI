using BlazorAuthAPI.Core.User.Dtos;
using BlazorAuthAPI.Core.User.Entities;

namespace BlazorAuthAPI.Core.User.Mappers
{
    public class UserMapper : IUserMapper
    {
        public Entities.User ToModel(UserRequest userRequest)
        {
            return new Entities.User
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
