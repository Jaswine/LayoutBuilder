using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Project;

namespace LayoutBuilder.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ProjectResponse<List<Project>>> GetAllProjects(string userId);
        Task<ProjectResponse<List<Project>>> GetAllPublicProjects();
        Task<ProjectResponse<Project>> GetOnePublicProject(int id);
        Task<ProjectResponse<Project>> GetProjectById(int id, string userId);
        Task<ProjectResponse<Project>> AddProject(string userId, CreateProjectDto newProject);
        Task<ProjectResponse<Project>> UpdateProject(int id, string userId, UpdateProjectDto updatedProject);
        Task<ProjectResponse<Project>> RemoveProjectById(int id, string userId);
    }
}