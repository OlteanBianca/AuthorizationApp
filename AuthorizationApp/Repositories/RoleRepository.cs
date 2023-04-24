using AuthorizationApp.DBContext;
using AuthorizationApp.Models;

namespace AuthorizationApp.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        #region Constructors
        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
