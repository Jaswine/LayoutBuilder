using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string ImageLink { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
    }
}