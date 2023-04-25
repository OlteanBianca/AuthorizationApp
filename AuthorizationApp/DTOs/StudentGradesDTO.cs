using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class StudentGradesDTO
    {
        #region Properties
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        public List<GradeDTO?>? Grades { get; set; }
        #endregion
    }
}
