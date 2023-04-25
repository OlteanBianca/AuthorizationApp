using AuthorizationApp.DTOs;

namespace AuthorizationApp.Services
{
    public interface IGradeService
    {
        #region Public Methods
        public Task<bool> AddGrade(GradeDTO grade, int studentId);

        public Task<bool> IsStudentIdValid(int studentId);
        #endregion
    }
}
