namespace BlazorAuthAPI.Core.Repository
{
    public interface ICrudRepository<TModel, in TId>
    {
        ICollection<TModel> FindAll();
        TModel Create(TModel model);
        void DeleteById(TId id);
    }
}
