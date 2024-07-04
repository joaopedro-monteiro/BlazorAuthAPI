using BlazorAuthAPI.Core.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.Repository.User
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<Models.User> Create(Models.User model)
        {
            var newUser = context.Users.Add(model).Entity;
            await context.SaveChangesAsync();
            return newUser;
        }

        public void DeleteById(Guid id)
        {
            var user = context.Users.Find(id);
            if (user == null)
                return;

            context.Users.Remove(user);
            context.SaveChanges();
        }

        public async Task<ICollection<Models.User>> FindAll() => await context.Users.ToListAsync();
    }
}
