using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.DTO;
using MyBlogProject.Repo;

namespace MyBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private UnitOfWork unitofwork = null;
        public CommentController(UnitOfWork uw)
        {
            unitofwork = uw;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            return Ok(unitofwork.CommentImplObject.GetAll());
        }
        [HttpPost]
        public IActionResult AddNewComment(CommentDTO newComment)
        {
            bool Status = unitofwork.CommentImplObject.Add(newComment);
            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(newComment);
            }
            else
            {
                return BadRequest("Error in adding Comment");
            }
        }
        [HttpPut]
        public IActionResult EditComment(int id, CommentDTO updatedComment)
        {
            bool status = unitofwork.CommentImplObject.Update(id, updatedComment);

            if (status)
            {
                unitofwork.SaveAll();
                return Ok(updatedComment);
            }

            return BadRequest("Error in updating comment");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            bool status = unitofwork.CommentImplObject.Delete(id);

            if (status)
            {
                unitofwork.SaveAll();
                return Ok(id);
            }

            return BadRequest("Error in deleting comment");
        }

    }
}
