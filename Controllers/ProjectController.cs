using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("list")]
        public async Task<ActionResult<List<Project>>> Get() 
        {
            return Ok( await _projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetSingle(int id) 
        {
            return Ok( await _projectService.GetProjectById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project newProject) 
        {
            return Ok(await _projectService.AddProject(newProject));
        }

    }
}