using AutoMapper;
using BlazorAuthAPI.Core.Data.Contexts;
using BlazorAuthAPI.Core.User.Commands;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.User.Services
{
    public class UserService(IMapper mapper, AppDbContext context) : IUserService
    {
        public async Task<Entities.User> CreateAsync(AddNewUserCommand userRequest)
        {
            var user = mapper.Map<Entities.User>(userRequest);

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null) throw new Exception("User not found");

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Entities.User>> FindAllAsync() => await context.Users.ToListAsync();
    }
}
