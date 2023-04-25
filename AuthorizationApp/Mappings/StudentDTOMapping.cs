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
                DateOfBirth = studentDTO.DateOfBirth
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
                DateOfBirth = student.DateOfBirth
            };

            return studentDTO;
        }
        #endregion
    }
}
