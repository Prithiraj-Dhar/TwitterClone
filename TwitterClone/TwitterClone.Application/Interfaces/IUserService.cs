using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        UserDto? CreateUser(CreateUserDto createUserDto);
        UserDto GetUserById(Guid id);
        UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto);
        UserDto? UpdateUserPhoneNumber(Guid id, string phoneNumber);
        bool DeleteUser(Guid id);
        List<UserDto> GetUsers();
    }
}
