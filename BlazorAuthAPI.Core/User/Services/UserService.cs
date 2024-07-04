using BlazorAuthAPI.Core.User.Commands;
using BlazorAuthAPI.Core.User.Entities;
using BlazorAuthAPI.Core.User.Repository.User;

namespace BlazorAuthAPI.Core.User.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<Entities.User> Create(AddNewUserCommand newUser)
        {
            //var createdUser = await userRepository.Create(newUser);

            return null;
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
