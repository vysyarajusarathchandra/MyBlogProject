using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.DTO;
using MyBlogProject.Repo;

namespace MyBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        UnitOfWork unitofwork = null;
        public RoleController(UnitOfWork uw)
        {
            unitofwork = uw;
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(unitofwork.RoleImplObject.GetAll());
        }

        [HttpPost]
        public IActionResult AddNewRole(RoleDTO roleNew)
        {
            bool Status = unitofwork.RoleImplObject.Add(roleNew);
            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(roleNew);
            }
            else
            {
                return BadRequest("Error In Adding Role");
            }
        }
        [HttpPut]
        public IActionResult UpdateRole(int Id, RoleDTO role)
        {
            bool Status = unitofwork.RoleImplObject.Update(Id, role);

            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(role);
            }
            else
            {
                return BadRequest("Error In Adding Role");
            }


        }
        [HttpDelete]
        public IActionResult DeleteRole(int Id)
        {
            bool Status = unitofwork.RoleImplObject.Delete(Id);

            if (Status)
            {
                unitofwork.SaveAll();
                return Ok(Id);
            }
            else
            {
                return BadRequest("Error In Deleting a  Role");
            }


        }
    }
}

