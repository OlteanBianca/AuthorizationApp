using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Repositories
{
    public class BaseRepository<T> where T : BaseModels
    {
        #region Private Fields
        private readonly DbSet<T> _dbSet;
        #endregion

        #region Public Fields
        public readonly AppDbContext _dbContext;
        #endregion

        #region Constructors
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        #endregion

        #region Protected Methods
        protected IQueryable<T> GetRecords()
        {
            return _dbSet.AsQueryable<T>();
        }
        #endregion

        #region Public Methods
        public List<T> GetAll()
        {
            return GetRecords().ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public T Insert(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public bool Any(Func<T, bool> expression)
        {
            return GetRecords().Any(expression);
        }
        #endregion
    }
}
