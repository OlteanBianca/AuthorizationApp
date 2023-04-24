using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Repositories
{
    public class GradeRepository : BaseRepository<Grade>
    {
        public GradeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Grade>> GetGradesByStudentId(int studentId)
        {    
            return await _dbContext.Grades.Where(grade => grade.StudentId == studentId).ToListAsync();
        }
    }
}
