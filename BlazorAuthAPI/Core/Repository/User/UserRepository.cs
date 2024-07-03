using BlazorAuthAPI.Core.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.Repository.User
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<Models.User> Create(Models.User model)
        {
            await context.Users.AddAsync(model);
            await context.SaveChangesAsync();

            return model;
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
