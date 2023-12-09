global using AutoMapper;
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

        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper)
        {
            _mapper = mapper;
        }

        // ! _____________  SHOW ALL PROJECTS _____________
        public async Task<ProjectResponse<List<Project>>> GetAllProjects()
        {
            var projectResponse = new ProjectResponse<List<Project>>();
            projectResponse.Data = projects.Select(c => _mapper.Map<Project>(c)).ToList();
            return projectResponse;
        }

        // ! _____________  SHOW ONE PROJECT _____________
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

        // ! _____________  CREATE A NEW PROJECT _____________
        public async  Task<ProjectResponse<Project>> AddProject(Project newProject)
        {
            var projectResponse = new ProjectResponse<Project>();

            newProject.Id = projects.Max(p => p.Id) + 1;
            projects.Add(newProject);

            projectResponse.Message = "Project created successfully";
            projectResponse.Data = newProject;
            return projectResponse;
        }

        // ! _____________  UPDATE PROJECT _____________
        public async Task<ProjectResponse<Project>> UpdateProject(Project updatedProject)
        {
            var projectResponse = new ProjectResponse<Project>();

            var existingProject = projects.FirstOrDefault(p => p.Id == updatedProject.Id);

            if (existingProject is not null)
            {
                // TODO: title's checking
                if (updatedProject.Title is not null && updatedProject.Title.Length > 0 && updatedProject.Title != existingProject.Title)
                {
                    existingProject.Title = updatedProject.Title;
                }

                // TODO: data checking
                if (updatedProject.Data is not null && updatedProject.Data.Length > 0 && updatedProject.Data != existingProject.Data)
                {
                    existingProject.Data = updatedProject.Data;
                }

                projectResponse.Message = "Project updated successfully";
                projectResponse.Data = existingProject;

                return projectResponse;
            }
            
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }
    }
}