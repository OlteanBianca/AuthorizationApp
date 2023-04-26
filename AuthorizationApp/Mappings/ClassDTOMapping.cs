using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Mappings
{
    public static class ClassDTOMapping
    {
        #region DTO to Entity
        public static Class? ToClass(this ClassDTO classDTO)
        {
            if (classDTO == null) return null;

            Class newClass = new()
            {
               Name = classDTO.Name,
               Students = classDTO.Students,
            };

            return newClass;
        }
        #endregion

        #region Entity To DTO
        public static ClassDTO? ToClassDTO(this Class studentClass)
        {
            if (studentClass == null) return null;

            ClassDTO classDTO = new()
            {
               Name = studentClass.Name,
               Students = studentClass.Students,
               StudentsCount = studentClass.Students.Count
            };

            return classDTO;
        }

        public static List<ClassDTO?> ToClassesDTO(this List<Class> classes)
        {
            classes ??= new();

            return classes.Select(val => val.ToClassDTO()).ToList();
        }
        #endregion
    }
}
