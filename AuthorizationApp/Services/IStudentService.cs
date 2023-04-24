using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAll();

        public Task<StudentDTO?> GetById(int studentId);

        public Task<List<GradeDTO?>> GetGradesById(int studentId);

        public List<string> GetClassStudents(int classId);

        public Dictionary<int, List<Student>> GetGroupedStudents();
    }
}
