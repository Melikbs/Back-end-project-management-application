using Collab_API.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using static DataAccess.Models.Sprint;
using static DataAccess.Models.SprintStatus;

namespace Collab_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly ISprint sprint;
        public SprintController(ISprint _sprint)
        {
            sprint = _sprint;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] sprintstatus? status )
        {
            return Ok(sprint.GetAllSprint(status));
        }
        [HttpPost]
        public IActionResult Post(AddUpdateSprint sprintObject)
        {
            var item = sprint.AddSprint(sprintObject);
            if (item == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Sprint Created Successfully !!!!",
                id = item!.Id

            });



        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateSprint sprintObject)
        {
            var item = sprint.UpdateSprint(id, sprintObject);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Sprint Updated Successfully !!!",
                id = item!.Id
            });

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!sprint.DeleteSprintById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Sprint deleted Successfully",
                id = id
            });
        }


    }
}
