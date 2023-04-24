using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationApp.Models;

public partial class Class : BaseModels
{
    #region Properties

    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;

    [NotMapped]
    public int StudentCount { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>(); 
    #endregion
}
