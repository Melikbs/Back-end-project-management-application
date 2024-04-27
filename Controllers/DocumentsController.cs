using Collab_API.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocument doc;
        public DocumentsController(IDocument document)
        {
            doc = document;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(doc.GetAllDocuments());
        }
        [HttpPost]
        public IActionResult Post(AddUpdateDocument documentObject)
        {
            var item = doc.AddDocuments(documentObject);
            if (item == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Document Created Successfully !!!!",
                id = item!.Id

            });



        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddUpdateDocument documentObject)
        {
            var item = doc.UpdateDocuments(id, documentObject);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = " Document Updated Successfully !!!",
                id = item!.Id
            });

        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!doc.DeleteDocumentsById(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Document deleted Successfully",
                id = id
            });
        }




    }
}
