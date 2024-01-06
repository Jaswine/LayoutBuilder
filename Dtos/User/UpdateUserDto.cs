using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Dtos.User
{
    public class UpdateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string About { get; set; } = string.Empty; 
        public string ImageLink { get; set; } = string.Empty; 
    }
}