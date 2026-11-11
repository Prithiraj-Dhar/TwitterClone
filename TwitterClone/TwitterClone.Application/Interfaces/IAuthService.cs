using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDto? Login(LoginDto loginDto);
    }
}
