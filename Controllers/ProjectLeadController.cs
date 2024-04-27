
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Collab_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Project Lead")]
    public class ProjectLeadController : ControllerBase
    {
        [HttpGet]
        public IActionResult ProjectLead([FromQuery] bool? projectlead)
        {
            if (projectlead == true)
            {
                return Ok("hello project lead");
            }
            return BadRequest();
        }
    }
}

