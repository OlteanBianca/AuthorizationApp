using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Services
{
    public interface IStudentService
    {
        #region Public Methods
        public Task<List<Student>> GetAll();

        public Task<StudentDTO?> GetById(int studentId);

        public Task<List<GradeDTO?>> GetGradesById(int studentId);

        public Task<List<StudentGradesDTO?>> GetStudentsGrades();
        #endregion
    }
}
