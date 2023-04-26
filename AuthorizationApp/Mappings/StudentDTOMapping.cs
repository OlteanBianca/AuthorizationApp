using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Mappings
{
    public static class StudentDTOMapping
    {
        #region DTO to Entity
        public static Student? ToStudent(this StudentDTO studentDTO)
        {
            if (studentDTO == null) return null;

            Student student = new()
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                Email = studentDTO.Email,
                ClassId = studentDTO.ClassId,
                Address = studentDTO.Address,
                DateOfBirth = studentDTO.DateOfBirth,
                Grades = studentDTO.Grades.ToGrades().Select(grade => grade).OfType<Grade>().ToList()
            };

            return student;
        }
        #endregion

        #region Entity To DTO
        public static StudentDTO? ToStudentDTO(this Student student)
        {
            if (student == null) return null;

            StudentDTO studentDTO = new()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                ClassId = student.ClassId,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth,
                Grades = student.Grades.ToList().ToGradesDTO().Select(grade => grade).OfType<GradeDTO>().ToList()
            };

            return studentDTO;
        }

        public static List<StudentDTO?> ToStudentsDTO(this List<Student> students)
        {
            students ??= new();
            return students.Select(student => student.ToStudentDTO()).ToList();
        }
        #endregion
    }
}
