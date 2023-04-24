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
        public User? GetByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(s => s.Email == email);
        }
        #endregion
    }
}
