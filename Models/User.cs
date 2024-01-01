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
        public string ImageLink { get; set; } = "";
        public string About { get; set; }  = "";

        public List<Project> Projects { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Collection> Collections { get; set; }


        public DateTime UpdatedAt { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}