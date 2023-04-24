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
        public void Register(RegisterDTO registerData)
        {
            if (registerData == null)
            {
                return;
            }

            Student? student = registerData.ToStudent();
            if (student == null)
            {
                return;
            }

            User? user = registerData.ToUser();
            if (user == null)
            {
                return;
            }

            var hashedPassword = _authService.HashPassword(registerData.Password);
            user.Password = hashedPassword;

            user = _unitOfWork.Users.Insert(user);
            student.Id = user.Id;

            _unitOfWork.Students.Insert(student);
            _unitOfWork.SaveChanges();
        }

        public string Validate(LoginDTO payload)
        {
            User? user = _unitOfWork.Users.GetByEmail(payload.Email);

            if (user != null && _authService.VerifyHashedPassword(user.Password, payload.Password))
            {
                Role? role = _unitOfWork.Roles.GetById(user.RoleId);

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
