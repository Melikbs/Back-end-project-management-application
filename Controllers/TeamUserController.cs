using Collab_API.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab_API.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class TeamUserController : ControllerBase
        {
            private readonly ITeamUser teamuser;
            public TeamUserController(ITeamUser _teamuser)
            {
                teamuser = _teamuser;
            }
            [HttpGet]
            public IActionResult Get()
            {

                return Ok(teamuser.GetAllTeamUsers());

            }
            [HttpPost]
            public IActionResult Post(AddUpdateTeamUser teamuserObject)
            {
                var item = teamuser.AddTeamUsers(teamuserObject);
                if (item == null)
                {
                    return BadRequest();
                }
                return Ok(new
                {
                    message = "TeamUser Created Successfully !!!!",
                    id = item!.Id

                });
            }
            
            [HttpDelete]
            [Route("{id}")]
            public IActionResult Delete([FromRoute] int id)
            {
                if (!teamuser.DeleteTeamUsersById(id))
                {
                    return NotFound();
                }
                return Ok(new
                {
                    message = "TeamUser deleted Successfully",
                    id = id
                });
            }

        }
    }
