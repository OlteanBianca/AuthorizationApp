using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.Models;

public partial class Grade : BaseModels
{
    #region Properties

    [Required, MaxLength(50)]
    public string Course { get; set; } = null!;

    [Required]
    public double Value { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }

    public virtual Student Student { get; set; } = null!;
    #endregion
}
