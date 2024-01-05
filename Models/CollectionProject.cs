using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Models
{
    public class CollectionProject
    {
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}