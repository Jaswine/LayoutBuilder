using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Dtos.Project
{
    public class UpdateProjectPublicDto
    {
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public string Description { get; set; }
        public bool AllowComments {get; set; }
    }
}