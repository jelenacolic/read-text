namespace ReadTextClient.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get(long id);
    }
}
