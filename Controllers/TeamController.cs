using Collab_API.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeam team;
        public TeamController(ITeam _team)
        {
            team = _team;
        }
        [HttpGet]
        public IActionResult Get() {

            return Ok(team.GetAllTeams());

        }
        [HttpPost]
        public IActionResult Post(AddUpdateTeam teamObject)
        {
            var item = team.AddTeams(teamObject);
            if (item == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Team Created Successfully !!!!",
                id = item!.Id

            });
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateTeam teamObject)
        {
            var item = team.UpdateTeams(id, teamObject);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Project Updated Successfully !!!",
                id = item!.Id
            });

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!team.DeleteTeamsById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Team deleted Successfully",
                id = id
            });
        }

    }
}
