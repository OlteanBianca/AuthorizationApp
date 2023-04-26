using AuthorizationApp.DTOs;
using AuthorizationApp.Mappings;
using AuthorizationApp.Models;
using AuthorizationApp.Repositories;

namespace AuthorizationApp.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Constructors
        public UserService(UnitOfWork unitOfWork, IAuthorizationService authService) : base(unitOfWork, authService)
        {
        }
        #endregion

        #region Public Methods
        public async Task<User?> AddUser(RegisterDTO registerData)
        {
            User? user = registerData.ToUser();
            if (user == null)
            {
                return null;
            }

            var hashedPassword = _authService.HashPassword(registerData.Password);
            user.Password = hashedPassword;

            user = await _unitOfWork.Users.Insert(user);
            await _unitOfWork.SaveChanges();
            return user;
        }

        public async Task<bool> AddStudent(RegisterDTO registerData, int userId)
        {
            Student? student = registerData.ToStudent();
            if (student == null)
            {
                return false;
            }
            student.Id = userId;

            await _unitOfWork.Students.Insert(student);
            await _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<LoginDTO?> Register(RegisterDTO registerData)
        {
            // Data is null or role is invalid.
            if (registerData == null || !await IsRoleValid(registerData.RoleId))
            {
                return null;
            }

            // If user is student but class is not valid.
            if (registerData.RoleId == 2 && !await IsClassValid(registerData.ClassId))
            {
                return null;
            }

            User? user = await AddUser(registerData);
            if (user == null)
            {
                return null;
            }

            // User is student.
            if (registerData.RoleId == 2)
            {
                await AddStudent(registerData, user.Id);
            }

            return registerData.ToLoginDTO();
        }

        public async Task<string> Validate(LoginDTO payload)
        {
            User? user = await _unitOfWork.Users.GetByEmail(payload.Email);

            if (user != null && _authService.VerifyHashedPassword(user.Password, payload.Password))
            {
                Role? role = await _unitOfWork.Roles.GetById(user.RoleId);

                if (role != null)
                {
                    return _authService.GetToken(user, role);
                }
            }
            return string.Empty;
        }

        public async Task<UserDTO?> FindUserByEmail(string email)
        {
            return (await _unitOfWork.Users.GetByEmail(email))?.ToUserDTO();
        }

        public async Task<UserDTO?> GetUserById(int id)
        {
            User? user = await _unitOfWork.Users.GetById(id);
            return user?.ToUserDTO();
        }

        public async Task<bool> CheckIfItsTeacher(int roleId)
        {
            Role? role = await _unitOfWork.Roles.GetTeacherRoleId();

            if (role == null) return false;

            return role.Id == roleId;
        }

        public async Task<bool> IsClassValid(int id)
        {
            Class? studentClass = await _unitOfWork.Classes.GetById(id);
            return studentClass != null;
        }

        public async Task<bool> IsRoleValid(int id)
        {
            Role? role = await _unitOfWork.Roles.GetById(id);
            return role != null;
        }
        #endregion
    }
}
