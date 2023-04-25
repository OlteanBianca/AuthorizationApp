using AuthorizationApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class UserDTO
    {
        #region Properties
        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
        #endregion
    }
}
