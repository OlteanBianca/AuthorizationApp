using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.Models;

public partial class User : BaseModels
{
    #region Properties

    [Required, MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required, MaxLength(50)]
    public string Password { get; set; } = null!;

    [Required]
    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Student? Student { get; set; }
    #endregion
}
