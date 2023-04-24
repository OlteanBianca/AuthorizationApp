using AuthorizationApp.DTOs;
using AuthorizationApp.Mappings;
using AuthorizationApp.Models;
using AuthorizationApp.Repositories;

namespace AuthorizationApp.Services
{
    public class StudentService : BaseService, IStudentService
    {
        #region Constructors
        public StudentService(UnitOfWork unitOfWork, IAuthorizationService authService) : base(unitOfWork, authService)
        {
        }
        #endregion

        #region Public Methods
        public List<Student> GetAll()
        {
            return _unitOfWork.Students.GetAll();
        }

        public StudentDTO? GetById(int studentId)
        {
            Student? student = _unitOfWork.Students.GetById(studentId);
            return student?.ToStudentDTO();
        }

        public List<string> GetClassStudents(int classId)
        {
            return _unitOfWork.Students.GetClassStudents(classId);
        }

        public Dictionary<int, List<Student>> GetGroupedStudents()
        {
            return _unitOfWork.Students.GetGroupedStudents();
        }
        #endregion
    }
}
