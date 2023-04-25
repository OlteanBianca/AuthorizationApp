using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        #region Constructors
        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods
        public async Task<Role?> GetTeacherRoleId()
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(role => role.UserRole == "Teacher");
        }
        #endregion
    }
}
