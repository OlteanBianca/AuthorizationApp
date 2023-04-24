using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        #region Constructors
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods
        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(s => s.Email == email);
        }
        #endregion
    }
}
