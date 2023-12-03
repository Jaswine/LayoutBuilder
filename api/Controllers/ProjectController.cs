using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LayoutBuilder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController: ControllerBase
    {
        private static List<Project> projects = new List<Project> {
            new Project {
                Id = 1,
                Title = "Project 1",
                Data = "<div></div>",
            }
        };

        [HttpGet("list")]
        public ActionResult<List<Project>> Get()
        {
            return Ok(projects);
        }

    }
}