using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Services
{
    public interface IStudentService
    {
        public List<Student> GetAll();

        public StudentDTO? GetById(int studentId);

        public List<string> GetClassStudents(int classId);

        public Dictionary<int, List<Student>> GetGroupedStudents();
    }
}
