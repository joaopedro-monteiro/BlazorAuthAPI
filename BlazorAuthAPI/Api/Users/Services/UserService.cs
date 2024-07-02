using BlazorAuthAPI.Api.Users.Dtos;
using BlazorAuthAPI.Api.Users.Mappers;
using BlazorAuthAPI.Core.Models;
using BlazorAuthAPI.Core.Repository.User;

namespace BlazorAuthAPI.Api.Users.Services
{
    public class UserService(IUserRepository userRepository, IUserMapper userMapper) : IUserService
    {
        public User Create(UserRequest userRequest)
        {
            var userToCreate = userMapper.ToModel(userRequest);
            var createdUser = userRepository.Create(userToCreate);

            return createdUser;
        }

        public void Delete(Guid id)
        {
            userRepository.DeleteById(id);
        }

        public ICollection<User> FindAll()
        {
            var users = userRepository.FindAll();

            return users;
        }
    }
}
