using AuthorizationApp.DTOs;
using AuthorizationApp.Mappings;
using AuthorizationApp.Models;
using AuthorizationApp.Repositories;

namespace AuthorizationApp.Services
{
    public class GradeService : BaseService, IGradeService
    {
        #region Constructors
        public GradeService(UnitOfWork unitOfWork, IAuthorizationService authService) : base(unitOfWork, authService)
        {
        }

        #endregion

        #region Public Methods
        public async Task<bool> AddGrade(GradeDTO gradeDTO, int studentID)
        {
            Grade? grade = gradeDTO.ToGrade();
            if(grade == null)
            {
                return false;
            }

            grade.StudentId = studentID;
            await _unitOfWork.Grades.Insert(grade);
            await _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<bool> IsStudentIdValid(int studentId)
        {
            return await _unitOfWork.Students.GetById(studentId) != null;
        }
        #endregion
    }
}
