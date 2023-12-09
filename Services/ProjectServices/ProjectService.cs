using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LayoutBuilder.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private static List<Project> projects = new List<Project> {
            new Project { Id = 1, Title = "Project 1", Data = "Data 1" },
            new Project { Id = 2, Title = "Project 2", Data = "Data 2" }
        };

        public async Task<ProjectResponse<List<Project>>> GetAllProjects()
        {
            var projectResponse = new ProjectResponse<List<Project>>();
            projectResponse.Data = projects;
            return projectResponse;
        }

        public async  Task<ProjectResponse<Project>> GetProjectById(int id)
        {
            var projectResponse = new ProjectResponse<Project>();

            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project is not null)
            {
                projectResponse.Data = project;
                return projectResponse;
            } 
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }

        public async  Task<ProjectResponse<Project>> AddProject(Project newProject)
        {
            var projectResponse = new ProjectResponse<Project>();

            newProject.Id = projects.Max(p => p.Id) + 1;
            projects.Add(newProject);

            projectResponse.Message = "Project created successfully";
            projectResponse.Data = newProject;
            return projectResponse;
        }
    }
}