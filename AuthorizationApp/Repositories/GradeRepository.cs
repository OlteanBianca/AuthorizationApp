using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Repositories
{
    public class GradeRepository : BaseRepository<Grade>
    {
        #region Constructors
        public GradeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region Public Methods
        public async Task<List<Grade>> GetGradesByStudentId(int studentId)
        {
            return await _dbContext.Grades.Where(grade => grade.StudentId == studentId).OrderBy(grade => grade.DateCreated).ToListAsync();
        }
        #endregion
    }
}
