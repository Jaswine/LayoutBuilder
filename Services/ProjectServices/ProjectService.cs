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

        public List<Project> GetAllProjects()
        {
            return projects;
        }

        public Project GetProjectById(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }

        public Project AddProject(Project newProject)
        {
            newProject.Id = projects.Max(p => p.Id) + 1;
            projects.Add(newProject);
            return newProject;
        }
    }
}