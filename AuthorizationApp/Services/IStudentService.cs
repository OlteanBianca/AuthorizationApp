using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Services
{
    public interface IStudentService
    {
        #region Public Methods
        public Task<List<Student>> GetAll();

        public Task<StudentDTO?> GetById(int studentId);

        public Task<StudentDTO?> GetByEmail(string email);

        public Task<List<GradeDTO?>> GetGradesById(int studentId);

        public Task<List<StudentGradesDTO?>> GetStudentsGrades();

        public Task<bool> EditName(StudentDTO payload, int id);

        public Task<List<StudentDTO?>> GetClassStudents(int classId);

        public Task<StudentDTO?> GetStudentCourseGrades(int studentId, string course);

        public Task<Dictionary<int, List<StudentDTO?>>> GetStudentsGroupedByClass();
        #endregion
    }
}
