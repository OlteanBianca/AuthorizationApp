using AuthorizationApp.DBContext;
using AuthorizationApp.Models;

namespace AuthorizationApp.Repositories
{
    public class ClassRepository : BaseRepository<Class>
    {
        #region Constructors
        public ClassRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods
        #endregion
    }
}
