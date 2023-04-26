using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Mappings
{
    public static class GradeDTOMapping
    {
        #region Entity To DTO
        public static GradeDTO? ToGradeDTO(this Grade grade)
        {
            if (grade == null)
            {
                return null;
            }

            GradeDTO gradeDTO = new()
            {
                Course = grade.Course,
                Value = grade.Value,
                DateCreated = grade.DateCreated,
            };

            return gradeDTO;
        }

        public static List<GradeDTO?> ToGradesDTO(this List<Grade> grades)
        {
            grades ??= new();

            return grades.Select(grade => grade.ToGradeDTO()).ToList();
        }

        public static StudentGradesDTO? ToStudentGradesDTO(this Student student, List<GradeDTO?> grades)
        {
            if (student == null)
            {
                return null;
            }

            StudentGradesDTO studentGradesDTO = new()
            {
                LastName = student.LastName,
                FirstName = student.FirstName,
                Grades = grades
            };

            return studentGradesDTO;
        }
        #endregion

        #region DTO to Entity
        public static Grade? ToGrade(this GradeDTO gradeDTO)
        {
            if (gradeDTO == null)
            {
                return null;
            }

            Grade grade = new()
            {
                Course = gradeDTO.Course,
                Value = gradeDTO.Value,
                DateCreated = gradeDTO.DateCreated
            };

            return grade;
        }

        public static List<Grade?> ToGrades(this List<GradeDTO> gradesDTO)
        {
            gradesDTO ??= new();
            return gradesDTO.Select(grade => grade.ToGrade()).ToList();
        }
        #endregion
    }
}
