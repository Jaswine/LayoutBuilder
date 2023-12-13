global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Data;
using Microsoft.EntityFrameworkCore; 

namespace LayoutBuilder.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        // private static List<Project> projects = new List<Project> {
        //     new Project { Id = 1, Title = "Project 1", Data = "Data 1", IsPublic = true },
        //     new Project { Id = 2, Title = "Project 2", Data = "Data 2", IsPublic = false}
        // };

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // ! _____________  SHOW ALL PROJECTS _____________
        public async Task<ProjectResponse<List<Project>>> GetAllProjects()
        {
            var projectResponse = new ProjectResponse<List<Project>>();
            // projectResponse.Data = projects.Select(c => _mapper.Map<Project>(c)).ToList();
            projectResponse.Data = await _context.Projects.Select(c => _mapper.Map<Project>(c)).ToListAsync();
            return projectResponse;
        }

        // ! _____________  SHOW ONE PROJECT _____________
        public async  Task<ProjectResponse<Project>> GetProjectById(int id)
        {
            var projectResponse = new ProjectResponse<Project>();

            // var project = projects.FirstOrDefault(p => p.Id == id);
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
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
        public async Task<ProjectResponse<Project>> AddProject(Project newProject)
        {
            var projectResponse = new ProjectResponse<Project>();

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            projectResponse.Message = "Project created successfully";
            projectResponse.Data = newProject;

            return projectResponse;
        }

        // ! _____________  UPDATE PROJECT _____________
        public async Task<ProjectResponse<Project>> UpdateProject(int id, Project updatedProject)
        {
            var projectResponse = new ProjectResponse<Project>();

            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

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

                await _context.SaveChangesAsync();

                projectResponse.Message = "Project updated successfully";
                projectResponse.Data = existingProject;

                return projectResponse;
            }
            
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }

        // ! _____________  REMOVE ONE PROJECT _____________
        public async  Task<ProjectResponse<Project>> RemoveProjectById(int id)
        {
            var projectResponse = new ProjectResponse<Project>();

            // var project = projects.FirstOrDefault(p => p.Id == id);
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (project is not null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();

                projectResponse.Message = "Project removed successfully!";
                return projectResponse;
            } 
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }
    }
}