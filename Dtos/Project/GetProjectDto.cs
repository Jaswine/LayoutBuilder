using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Dtos.Project
{
    public class GetProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string? Data { get; set; }

        public string? UpdatedAt { get; set; } 
        public string? CreatedAt { get; set; } 
    }
}