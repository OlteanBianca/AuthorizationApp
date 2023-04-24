using AuthorizationApp.DBContext;
using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

     

        public List<string> GetClassStudents(int classId)
        {
            var results = _dbContext.Students
                .Include(e => e.Grades.Where(e => e.Value > 5))

                .Where(e => e.ClassId == classId)

                .OrderByDescending(e => e.FirstName)
                    .ThenByDescending(e => e.LastName)

                .Select(e => e.FirstName + "" + e.LastName)

                .ToList();

            return results;
        }

        public Dictionary<int, List<Student>> GetGroupedStudents()
        {
            var results = _dbContext.Students
                .GroupBy(e => e.ClassId)
                .Select(e => new { ClassId = e.Key, Students = e.ToList() })
                .ToDictionary(e => e.ClassId, e => e.Students);

            return results;
        }

        //public Student? GetByEmail(string email)
        //{
        //    return _dbContext.Students.FirstOrDefault(s => s.Email == email);
        //}
    }
}
