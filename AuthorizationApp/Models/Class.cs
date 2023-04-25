using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.Models;

public partial class Class : BaseModels
{
    #region Properties
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    #endregion
}
