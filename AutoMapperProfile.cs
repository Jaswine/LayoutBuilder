using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, ProjectResponse<Project>>();
            CreateMap<Project, ProjectResponse<List<Project>>>();
        }
    }
}