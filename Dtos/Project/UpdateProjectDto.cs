using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Dtos.Project
{
    public class UpdateProjectDto
    {
        public string Title { get; set; }
        public string Data { get; set; }
        public bool IsPublic { get; set; } = false;

    }
}