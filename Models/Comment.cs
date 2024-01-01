using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime UpdatedAt { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}