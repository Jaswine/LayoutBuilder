using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Project Title";
        public string? Data { get; set; } = "";

        public bool IsPublic { get; set; } = false;
        public string Description { get; set; } = "";
        public object? tags { get; set; } = "";
    }
}