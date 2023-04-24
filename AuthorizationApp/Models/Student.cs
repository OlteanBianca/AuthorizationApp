using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.Models;

public partial class Student : BaseModels
{
    #region Properties

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    [Required, MaxLength(50)]
    public string Address { get; set; } = string.Empty;

    [Required]
    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual User UserData { get; set; } = null!;
    #endregion
}
