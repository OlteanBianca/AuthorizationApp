using AuthorizationApp.DTOs;

namespace AuthorizationApp.Services
{
    public interface IClassService
    {
        #region Properties
        public Task<List<ClassDTO?>> GetAllClassesWithStudentsCount();

        public Task<bool> AddClass(ClassDTO classDTO);

        public Task<List<ClassDTO?>> GetAll();
        #endregion
    }
}
