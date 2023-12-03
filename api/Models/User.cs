using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = "username";
        public string Email { get; set; } = "user@gmail.com";
        public string Password { get; set; } = ".....";

        public string About { get; set; } = "Some description about the user";
        public string Location { get; set; } = "";

        public string GitHubLink { get; set; } = "";
        public string LinkedinLink { get; set; } = "";
        public string InstagramLink { get; set; } = "";
        public string WebsiteLink { get; set; } = "";

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}