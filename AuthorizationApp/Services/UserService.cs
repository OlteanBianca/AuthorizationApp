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
        public async Task<bool> Register(RegisterDTO registerData)
        {
            if (registerData == null)
            {
                return false;
            }

            Student? student = registerData.ToStudent();
            if (student == null)
            {
                return false;
            }

            User? user = registerData.ToUser();
            if (user == null)
            {
                return false;
            }

            var hashedPassword = _authService.HashPassword(registerData.Password);
            user.Password = hashedPassword;

            user = await _unitOfWork.Users.Insert(user);
            await _unitOfWork.SaveChanges();
            student.Id = user.Id;

            await _unitOfWork.Students.Insert(student);
            await _unitOfWork.SaveChanges();

            return true;
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
        #endregion
    }
}
