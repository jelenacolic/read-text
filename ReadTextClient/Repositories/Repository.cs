using Microsoft.EntityFrameworkCore;

namespace ReadTextClient.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        static Repository<TEntity> _instance;

        private Repository(TextContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public static Repository<TEntity> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Repository<TEntity>(new TextContext());
                }

                return _instance;
            }
            
        }


        public TEntity Get(long id)
        {
            return _dbSet.Find(id);
        }
    }
}
