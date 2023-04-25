using AuthorizationApp.DBContext;
using AuthorizationApp.Models;

namespace AuthorizationApp.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        #region Constructors
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods     
        #endregion
    }
}
