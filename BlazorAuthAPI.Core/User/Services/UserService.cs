using BlazorAuthAPI.Core.User.Commands;
using BlazorAuthAPI.Core.User.Entities;
using BlazorAuthAPI.Core.User.Mappers;
using BlazorAuthAPI.Core.User.Repository.User;

namespace BlazorAuthAPI.Core.User.Services
{
    public class UserService(IUserRepository userRepository, IUserMapper userMapper) : IUserService
    {
        public async Task<Entities.User> Create(AddNewUserCommand userRequest)
        {
            var userToCreate = userMapper.ToModel(userRequest);
            var createdUser = await userRepository.Create(userToCreate);

            return createdUser;
        }

        public void Delete(Guid id)
        {
            userRepository.DeleteById(id);
        }

        public async Task<ICollection<Entities.User>> FindAll()
        {
            var users = await userRepository.FindAll();

            return users;
        }
    }
}
