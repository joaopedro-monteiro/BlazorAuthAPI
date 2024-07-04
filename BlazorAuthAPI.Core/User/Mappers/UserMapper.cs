using BlazorAuthAPI.Core.User.Commands;
using BlazorAuthAPI.Core.User.Entities;

namespace BlazorAuthAPI.Core.User.Mappers
{
    public class UserMapper : IUserMapper
    {
        public Entities.User ToModel(AddNewUserCommand userRequest)
        {
            return new Entities.User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                PasswordHashed = userRequest.Password,
                Cpf = userRequest.Cpf,
                Role = userRequest.Role
            };
        }
    }
}
