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
        private static List<Project> projects = new List<Project> {
            new Project { Id = 1, Title = "Project 1", Data = "Data 1" },
            new Project { Id = 2, Title = "Project 2", Data = "Data 2" }
        };

        [HttpGet("list")]
        public ActionResult<List<Project>> Get() 
        {
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetSingle(int id) 
        {
            return Ok(projects.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost("create")]
        public ActionResult<List<Project>> AddProject(Project newProject) 
        {
            newProject.Id = projects.Max(p => p.Id) + 1;
            projects.Add(newProject);
            return Ok(projects);
        }

    }
}