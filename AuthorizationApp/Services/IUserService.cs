using AuthorizationApp.DTOs;

namespace AuthorizationApp.Services
{
    public interface IUserService
    {
        public void Register(RegisterDTO registerData);

        public string Validate(LoginDTO payload);
    }
}
