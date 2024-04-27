using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.Identity.Client;

namespace Collab_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _project;
        public ProjectController(IProject project)
        {
            _project = project;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_project.GetAllProjects(isActive));
        }
        [HttpPost]
        public IActionResult Post(AddUpdateProject projectObject)
        {
            var item = _project.AddProjects(projectObject);
            if (item == null) {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Project Created Successfully !!!!",
                id = item!.Id

            });



        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateProject projectObject)
        {
            var item = _project.UpdateProjects(id, projectObject);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message="Project Updated Successfully !!!",
                id = item!.Id
            });

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_project.DeleteProjectsById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Project deleted Successfully",
                id = id
            });
        }




    }
}
