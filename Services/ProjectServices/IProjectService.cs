using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutBuilder.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();

        Task<Project> GetProjectById(int id);

        Task<Project> AddProject(Project newProject);
    }
}