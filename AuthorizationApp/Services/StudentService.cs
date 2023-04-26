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

        public async Task<StudentDTO?> GetByEmail(string email)
        {
            return (await _unitOfWork.Students.GetStudentByEmail(email))?.ToStudentDTO();
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

        public async Task<bool> EditName(StudentDTO payload, int id)
        {
            if (payload == null)
            {
                return false;
            }

            Student? student = await _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return false;
            }

            student.FirstName = payload.FirstName;
            student.LastName = payload.LastName;

            _unitOfWork.Students.Update(student);
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<List<StudentDTO?>> GetClassStudents(int classId)
        {
            return (await _unitOfWork.Students.GetClassStudentsWithPassingGrade(classId)).ToStudentsDTO();
        }

        public async Task<StudentDTO?> GetStudentCourseGrades(int studentId, string course)
        {
            return (await _unitOfWork.Students.GetStudentCourseGrades(studentId, course))?.ToStudentDTO();
        }

        public async Task<Dictionary<int, List<StudentDTO?>>> GetStudentsGroupedByClass()
        {
            return (await _unitOfWork.Students.GetStudentsGroupedByClass()).Select(pair => new KeyValuePair<int, List<StudentDTO?>>
            (
                pair.Key,
                pair.Value.Select(student => student.ToStudentDTO()).ToList()
            )).ToDictionary(e => e.Key, e => e.Value);
        }
        #endregion
    }
}
