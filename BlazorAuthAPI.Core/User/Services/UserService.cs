using BlazorAuthAPI.Api.Users.Dtos;
using BlazorAuthAPI.Api.Users.Mappers;
using BlazorAuthAPI.Core.Models;
using BlazorAuthAPI.Core.Repository.User;

namespace BlazorAuthAPI.Api.Users.Services
{
    public class UserService(IUserRepository userRepository, IUserMapper userMapper) : IUserService
    {
        public async Task<User> Create(UserRequest userRequest)
        {
            var userToCreate = userMapper.ToModel(userRequest);
            var createdUser = await userRepository.Create(userToCreate);

            return createdUser;
        }

        public void Delete(Guid id)
        {
             userRepository.DeleteById(id);
        }

        public async Task<ICollection<User>> FindAll()
        {
            var users = await userRepository.FindAll();

            return users;
        }
    }
}
