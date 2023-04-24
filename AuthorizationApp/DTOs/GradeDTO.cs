using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class GradeDTO
    {
        [Required, MaxLength(50)]
        public string Course { get; set; } = null!;

        [Required]
        public double Value { get; set; }
    }
}
