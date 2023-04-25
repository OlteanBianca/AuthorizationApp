using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Mappings
{
    public static class RegisterDTOMapping
    {
        #region DTO to Entity

        public static Student? ToStudent(this RegisterDTO registerData)
        {
            if (registerData == null) return null;

            Student student = new()
            {
                FirstName = registerData.FirstName,
                LastName = registerData.LastName,
                Email = registerData.Email,
                ClassId = registerData.ClassId,
                Address = registerData.Address,
                DateOfBirth = registerData.DateOfBirth
            };

            return student;
        }

        public static User? ToUser(this RegisterDTO registerData)
        {
            if (registerData == null) return null;

            User user = new()
            {
                Email = registerData.Email,
                RoleId = registerData.RoleId,
                Password = registerData.Password,
            };

            return user;
        }

        public static LoginDTO? ToLoginDTO(this RegisterDTO registerData)
        {
            if (registerData == null) return null;

            LoginDTO loginDTO = new()
            {
                Email = registerData.Email,
                Password = registerData.Password,
            };

            return loginDTO;
        }
        #endregion
    }
}
