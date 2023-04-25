using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.Models;

public partial class Role : BaseModels
{
    #region Properties
    [Required, MaxLength(50)]
    public string UserRole { get; set; } = string.Empty;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
    #endregion
}
