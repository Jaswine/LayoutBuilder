global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using LayoutBuilder.Data;
using LayoutBuilder.Dtos.Project;
using Microsoft.EntityFrameworkCore; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LayoutBuilder.Utils;
using Newtonsoft.Json;


namespace LayoutBuilder.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // ! _____________  SHOW ALL PROJECTS _____________
        public async Task<ProjectResponse<List<Project>>> GetAllProjects(string userId)
        {
            var projectResponse = new ProjectResponse<List<Project>>();
            projectResponse.Data = await _context.Projects.Include(p => p.User).Where(p => p.UserId == int.Parse(userId)).ToListAsync();
            return projectResponse;
        }

          // ! _____________  SHOW PUBLIC PROJECT BY ID _____________
        public async Task<ProjectResponse<Project>> GetOnePublicProject(int id)
        {
            var projectResponse = new ProjectResponse<Project>();

            var project = await _context.Projects.Include(p => p.User).Include(u => u.Comments).FirstOrDefaultAsync(p => p.Id == id);
            if (project is not null)
            {
                projectResponse.Data = project;
                return projectResponse;
            } 

            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }


        // ! _____________  SHOW PROJECT BY ID _____________
        [Authorize]
        public async  Task<ProjectResponse<Project>> GetProjectById(int id, string userId)
        {
            var projectResponse = new ProjectResponse<Project>();

            // var project = projects.FirstOrDefault(p => p.Id == id);
            var project = await _context.Projects.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
            if (project is not null)
            {
                if (project.UserId == int.Parse(userId)) {
                    projectResponse.Data = project;
                    return projectResponse;
                }
            } 

            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }

        // ! _____________  CREATE A NEW PROJECT _____________
        public async Task<ProjectResponse<Project>> AddProject(string userId, CreateProjectDto newProject)
        {
            var projectResponse = new ProjectResponse<Project>();
            DateTime currentDateAndTime = DateTime.Now;

            var project = new Project();
            project.Title = newProject.Title;
            project.IsPublic = false;
            project.Description = "";
           
            project.UserId = int.Parse(userId);

            project.UpdatedAt = currentDateAndTime;
            project.CreatedAt = currentDateAndTime;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            projectResponse.Message = "Project created successfully";
            projectResponse.Data = project;

            return projectResponse;
        }
        
        // ! _____________  UPDATE PROJECT TO PUBLIC _____________
        public async Task<ProjectResponse<Project>> UpdateProjectToPublic(int id, string userId, UpdateProjectPublicDto updatedProject)
        {
            var projectResponse = new ProjectResponse<Project>();
            DateTime currentDateAndTime = DateTime.Now;

            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProject is not null)
            {
                if (existingProject.UserId == int.Parse(userId)) {
                    if (updatedProject.Title is not null && updatedProject.Title.Length > 0 && updatedProject.Title != existingProject.Title)
                    {
                        existingProject.Title = updatedProject.Title;
                    }
                    
                    existingProject.Description = updatedProject.Description;
                    existingProject.AllowComments = updatedProject.AllowComments;
                    existingProject.IsPublic = updatedProject.IsPublic;
                    existingProject.UpdatedAt = currentDateAndTime;

                    await _context.SaveChangesAsync();

                    projectResponse.Message = "Project updated successfully";
                    projectResponse.Data = existingProject;

                    return projectResponse;
                }
            }
            
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }

        // ! _____________  UPDATE PROJECT TITLE _____________
        public async Task<ProjectResponse<Project>> UpdateProjectTitle(int id, string userId, UpdateProjectTitleDto updatedProject)
        {
            var projectResponse = new ProjectResponse<Project>();
            DateTime currentDateAndTime = DateTime.Now;

            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProject is not null)
            {
                if (existingProject.UserId == int.Parse(userId)) {
                    existingProject.Title = updatedProject.Title;

                    await _context.SaveChangesAsync();

                    projectResponse.Message = "Project updated successfully";
                    projectResponse.Data = existingProject;

                    return projectResponse;
                }
            }
            
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }

         // ! _____________  UPDATE PROJECT DATA _____________
        public async Task<ProjectResponse<Project>> UpdateProjectData(int id, string userId, UpdateProjectDataDto updatedProject)
        {
            var projectResponse = new ProjectResponse<Project>();
            DateTime currentDateAndTime = DateTime.Now;

            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProject is not null)
            {
                if (existingProject.UserId == int.Parse(userId)) {
                    existingProject.Data = updatedProject.Data;

                    await _context.SaveChangesAsync();

                    projectResponse.Message = "Project updated successfully";
                    projectResponse.Data = existingProject;

                    return projectResponse;
                }
            }
            
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }

        // ! _____________  REMOVE PROJECT _____________
        public async  Task<ProjectResponse<Project>> RemoveProjectById(int id, string userId)
        {
            var projectResponse = new ProjectResponse<Project>();

            // var project = projects.FirstOrDefault(p => p.Id == id);
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (project is not null)
            {
                if (project.UserId == int.Parse(userId)) {
                    _context.Projects.Remove(project);
                    await _context.SaveChangesAsync();

                    projectResponse.Message = "Project removed successfully!";
                    return projectResponse;
                }
            } 
            projectResponse.Success = false;
            projectResponse.Message = "Project Not Found";
            return projectResponse;
        }
    }
}