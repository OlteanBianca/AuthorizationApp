using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Services
{
    public interface IUserService
    {
        #region Public Methods
        public Task<User?> AddUser(RegisterDTO registerData);

        public Task<bool> AddStudent(RegisterDTO registerData, int userId);

        public Task<LoginDTO?> Register(RegisterDTO registerData);

        public Task<string> Validate(LoginDTO payload);

        public Task<UserDTO?> GetUserById(int id);

        public Task<UserDTO?> FindUserByEmail(string email);

        public Task<bool> CheckIfItsTeacher(int teacherId);

        public Task<bool> IsClassValid(int id);
        #endregion
    }
}
