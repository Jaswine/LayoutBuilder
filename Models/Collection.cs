using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Project> Projects { get; set; }

        public bool IsFavorite { get; set; }

        public DateTime UpdatedAt { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}