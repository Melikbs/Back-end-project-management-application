using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostSharp.Aspects.Dependencies;

namespace Collab_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : ControllerBase
    {
        [HttpGet]   
        public string Admin([FromQuery] bool? admin)
        {
             return "hello admin";
            
        }

    }
}
