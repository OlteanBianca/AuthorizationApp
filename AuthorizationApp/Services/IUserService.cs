using AuthorizationApp.DTOs;

namespace AuthorizationApp.Services
{
    public interface IUserService
    {
        public Task<bool> Register(RegisterDTO registerData);

        public Task<string> Validate(LoginDTO payload);
    }
}
