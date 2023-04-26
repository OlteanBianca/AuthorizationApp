using AuthorizationApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class StudentDTO
    {
        #region Properties
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int ClassId { get; set; }

        public List<GradeDTO> Grades { get; set; } = new();
        #endregion
    }
}
