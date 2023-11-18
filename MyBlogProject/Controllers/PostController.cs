using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.DTO;
using MyBlogProject.Repo;

namespace MyBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private UnitOfWork unitofwork = null;
        public PostController(UnitOfWork uw)
        {
            unitofwork = uw;
        }
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            return Ok(unitofwork.PostImplObject.GetAll());
        }
        [HttpPost]
        public IActionResult AddNewPost(PostDTO newPost)
        {
            bool Status = unitofwork.PostImplObject.Add(newPost);
            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(newPost);
            }
            else
            {
                return BadRequest("Error in adding post");
            }
        }
        [HttpPut("{id}")]
        public IActionResult EditPost(int id, PostDTO updatedPost)
        {
            bool Status = unitofwork.PostImplObject.Update(id, updatedPost);
            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(updatedPost);
            }
            else
            {
                return BadRequest($"Error in updating post with ID {id}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            bool Status = unitofwork.PostImplObject.Delete(id);
            if (Status)
            {
                unitofwork.SaveAll();
                return Ok($"Post with ID {id} deleted");
            }
            else
            {
                return BadRequest($"Error in deleting post with ID {id}");
            }
        }
    }
}
