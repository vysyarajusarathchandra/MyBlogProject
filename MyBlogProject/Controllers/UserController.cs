using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.DTO;
using MyBlogProject.Repo;

namespace MyBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UnitOfWork unitofwork = null;
        public UserController(UnitOfWork uw)
        {
            unitofwork = uw;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(unitofwork.UserImplObject.GetAll());
        }

        [HttpPost]
        public IActionResult AddNewUser(UserDTO usrNew)
        {
            bool Status = unitofwork.UserImplObject.Add(usrNew);
            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(usrNew);
            }
            else
            {
                return BadRequest("Error In Adding User");
            }
        }
        [HttpPut]
        public IActionResult UpdateUser(int Id, UserDTO item)
        {
            bool Status = unitofwork.UserImplObject.Update(Id, item);

            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(item);
            }
            else
            {
                return BadRequest("Error In Updating User");
            }
        }
        [HttpDelete]
        public IActionResult DeleteUser(int Id)
        {
            bool Status = unitofwork.RoleImplObject.Delete(Id);

            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(Id);
            }
            else
            {
                return BadRequest("Error In Deleting a  User");
            }


        }

    }
}
