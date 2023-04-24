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
        public async Task<List<Student>> GetAll()
        {
            return await _unitOfWork.Students.GetAll();
        }

        public async Task<StudentDTO?> GetById(int studentId)
        {
            Student? student = await _unitOfWork.Students.GetById(studentId);
            return student?.ToStudentDTO();
        }

        public async Task<List<GradeDTO?>> GetGradesById(int studentId)
        {
            List<Grade> grades =  await _unitOfWork.Grades.GetGradesByStudentId(studentId);
            return grades.ToGradesDTO();
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
