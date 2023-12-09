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
        public ActionResult<List<Project>> Get() 
        {
            return Ok(_projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetSingle(int id) 
        {
            return Ok(_projectService.GetProjectById(id));
        }

        [HttpPost]
        public ActionResult<Project> AddProject(Project newProject) 
        {
            return Ok(_projectService.AddProject(newProject));
        }

    }
}