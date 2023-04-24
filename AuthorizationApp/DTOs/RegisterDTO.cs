using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class RegisterDTO
    {
        #region Properties

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Password { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int RoleId { get; set; }
        #endregion
    }
}
