using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Services.ProjectServices
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();

        Project GetProjectById(int id);

        Project AddProject(Project newProject);
    }
}