using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Data { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Comment> Comments { get; set; }


        public bool IsPublic { get; set; } = false;

        public DateTime UpdatedAt { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}