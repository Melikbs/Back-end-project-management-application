using Collab_API.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Collab_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _task;
        public TaskController(ITask task)
        {
            _task = task;
        }

        [HttpGet]
        public IActionResult Get()
        
        {
           return Ok(_task.GetAllTasks());
        }
        [HttpPost]
        public IActionResult Post(AddUpdateTask taskObject)
        {
            var item = _task.AddTasks(taskObject);
            if (item == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "task Created Successfully !!!!",
                id = item!.Id

            });
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_task.DeleteTasksById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Task deleted Successfully",
                id = id
            });
        }



    }
}
    

