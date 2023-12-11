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
        public int UserId { get; set; }
        public string? Data { get; set; }
        public bool IsPublic { get; set; } = false;

        public string? UpdatedAt { get; set; } 
        public string? CreatedAt { get; set; } 
    }
}