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
            List<Grade> grades = await _unitOfWork.Grades.GetGradesByStudentId(studentId);
            return grades.ToGradesDTO();
        }

        public async Task<List<StudentGradesDTO?>> GetStudentsGrades()
        {
            List<Student> students = await GetAll();
            List<StudentGradesDTO?> studentsGrades = new();

            foreach (Student student in students)
            {
                List<GradeDTO?> grades = await GetGradesById(student.Id);
                studentsGrades.Add(student.ToStudentGradesDTO(grades));
            }
            return studentsGrades;
        }
        #endregion
    }
}
