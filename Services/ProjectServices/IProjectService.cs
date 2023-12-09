using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ProjectResponse<List<Project>>> GetAllProjects();

        Task<ProjectResponse<Project>> GetProjectById(int id);

        Task<ProjectResponse<Project>> AddProject(Project newProject);

        Task<ProjectResponse<Project>> UpdateProject(Project updatedProject);
    }
}