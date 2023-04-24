using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class LoginDTO
    {
        #region Properties

        [Required, MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Password { get; set; } = string.Empty;
        #endregion
    }
}
