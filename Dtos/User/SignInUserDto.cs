using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Dtos.User
{
    public class SignInUserDto
    {
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;
    }
}