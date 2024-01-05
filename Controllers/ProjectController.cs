using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Project;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using LayoutBuilder.Utils;

namespace LayoutBuilder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService) 
        {
            _projectService = projectService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<List<Project>>> Get() 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok( await _projectService.GetAllProjects(userId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetPublicSingle(int id) 
        {
            return Ok( await _projectService.GetOnePublicProject(id));
        }
        
        [HttpGet("dashboard/{id}")]
        public async Task<ActionResult<Project>> GetSingle(int id) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            var response = await _projectService.GetProjectById(id, userId);
            
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(CreateProjectDto newProject) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _projectService.AddProject(userId, newProject));
        }

        [HttpPut("{id}/public")]
        public async Task<ActionResult<Project>> UpdateProjectToPublic(int id, UpdateProjectPublicDto  updatedProject) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _projectService.UpdateProjectToPublic(id, userId, updatedProject));
        }

        [HttpPut("{id}/title")]
        public async Task<ActionResult<Project>> UpdateTitleProject(int id, UpdateProjectTitleDto  updatedProject) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _projectService.UpdateProjectTitle(id, userId, updatedProject));
        }

        [HttpPut("{id}/data")]
        public async Task<ActionResult<Project>> UpdateDataProject(int id, UpdateProjectDataDto  updatedProject) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _projectService.UpdateProjectData(id, userId, updatedProject));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> RemoveProject(int id) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok( await _projectService.RemoveProjectById(id, userId));
        }
    }
}