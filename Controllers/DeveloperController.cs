using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collab_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Developer")]
    public class DeveloperController : ControllerBase
    {
        [HttpGet]
        public string Developer()
        {
            return "hello developer";
        }
    }
}
