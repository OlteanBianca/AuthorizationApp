using AuthorizationApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class StudentDTO
    {
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
    }
}
