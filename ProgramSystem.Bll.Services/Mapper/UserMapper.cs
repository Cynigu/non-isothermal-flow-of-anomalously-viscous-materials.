using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Bll.Services.Mapper
{
    public static class UserMapper
    {
        public static UserDTO ToDto(this UserEntity? user)
        {
            if (user == null)
                throw new ArgumentNullException();

            return new UserDTO()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static UserEntity ToEntity(this UserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException();

            return new UserEntity()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role
            };
        }
    }
}
