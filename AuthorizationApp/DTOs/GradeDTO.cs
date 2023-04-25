using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class GradeDTO
    {
        #region Properties
        [Required, MaxLength(50)]
        public string Course { get; set; } = null!;

        [Required]
        public double Value { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        #endregion
    }
}
