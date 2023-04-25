using AuthorizationApp.DTOs;
using AuthorizationApp.Models;

namespace AuthorizationApp.Mappings
{
    public static class UserDTOMapping
    {
        #region DTO to Entity
        public static User? ToUser(this UserDTO userDTO)
        {
            if (userDTO == null) return null;

            User user = new()
            {
                RoleId = userDTO.RoleId,
                Role = userDTO.Role,
            };

            return user;
        }
        #endregion

        #region Entity To DTO
        public static UserDTO? ToUserDTO(this User user)
        {
            if (user == null) return null;

            UserDTO userDTO = new()
            {
                RoleId = user.RoleId,
                Role = user.Role,
            };

            return userDTO;
        }
        #endregion
    }
}
