using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateTime) GetToken(UserDto user);
    }
}
