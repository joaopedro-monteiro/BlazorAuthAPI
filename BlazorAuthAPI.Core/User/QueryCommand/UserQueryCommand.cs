using BlazorAuthAPI.Core.User.Enum;
using BlazorAuthAPI.Core.Shared;

namespace BlazorAuthAPI.Core.User.QueryCommand
{
    public class UserQueryCommand
    {
        private string? _query;

        public string? Query
        {
            get => _query;
            set => _query = value?.Trim();
        }

        public List<AccessLevel> AccessLevels { get; set; } = EnumHelper.GetValues<AccessLevel>().ToList();

        public IQueryable<Entities.User> ApplyFilter(IQueryable<Entities.User> queryable)
        {
            if (!string.IsNullOrEmpty(Query))
            {
                queryable = queryable.Where(w => w.Name!.Contains(Query)
                                                 || w.Email!.Contains(Query)
                                                 || w.Cpf!.Contains(Query));
            }

            if (AccessLevels.Any())
                queryable = queryable.Where(w => AccessLevels.Contains(w.Role));

            return queryable;
        }
    }
}
