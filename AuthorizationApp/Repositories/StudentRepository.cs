using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Student>> GetClassStudentsWithPassingGrade(int classId)
        {
            return await _dbContext.Students.Include(e => e.Grades.Where(e => e.Value > 5))
                                            .Where(e => e.ClassId == classId)
                                            .OrderByDescending(e => e.FirstName)
                                            .ThenByDescending(e => e.LastName)
                                            .Select(e => e).ToListAsync();
        }

        public async Task<Student?> GetStudentCourseGrades(int studentId, string course)
        {
            Student? student = await _dbContext.Students.Include(grade => grade.Grades).FirstOrDefaultAsync(e => e.Id == studentId);

            if(student == null)
            {
                return null;
            }

            student.Grades = student.Grades.Where(g => g.Course == course).OrderByDescending(g => g.Value).ToList();
            return student;
        }

        public async Task<Dictionary<int, List<Student>>> GetStudentsGroupedByClass()
        {
            return await _dbContext.Students.Include(student => student.Grades).GroupBy(e => e.ClassId)
                .Select(e => new { ClassId = e.Key, Students = e.ToList() })
                .ToDictionaryAsync(e => e.ClassId, e => e.Students);
        }

        public async Task<Student?> GetStudentByEmail(string email)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
        }
        #endregion
    }
}
