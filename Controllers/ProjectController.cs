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

         [HttpGet("list")]
        public async Task<ActionResult<List<Project>>> GetPublicProjects() 
        {

            return Ok( await _projectService.GetAllPublicProjects());
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

            return Ok( await _projectService.GetProjectById(id, userId));
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(CreateProjectDto newProject) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _projectService.AddProject(userId, newProject));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, UpdateProjectDto  updatedProject) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _projectService.UpdateProject(id, userId, updatedProject));
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