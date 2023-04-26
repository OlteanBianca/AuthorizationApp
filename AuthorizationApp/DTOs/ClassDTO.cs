using AuthorizationApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationApp.DTOs
{
    public class ClassDTO
    {
        #region Properties
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        public int StudentsCount { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        #endregion
    }
}
