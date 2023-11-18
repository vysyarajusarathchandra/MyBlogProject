using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject.DTO;
using MyBlogProject.Repo;

namespace MyBlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private UnitOfWork unitofwork = null;
        public CategoryController(UnitOfWork uw)
        {
            unitofwork = uw;
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(unitofwork.CategoryImplObject.GetAll());
        }

        [HttpPost]
        public IActionResult AddNewCategory(CategoryDTO newcategory)
        {

            if (newcategory == null)
            {
                return BadRequest("Category data is null.");
            }

            string errorMessage = string.Empty;

            try
            {
                bool status = unitofwork.CategoryImplObject.Add(newcategory);

                if (status)
                {
                    unitofwork.SaveAll();
                    return Ok(newcategory);
                }
                else
                {
                    errorMessage = "Error adding new category.";
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return BadRequest(errorMessage);
        }
        [HttpPut]
        public IActionResult EditCategory(int Id, CategoryDTO updatedCategory)
        {
            string errorMessage = string.Empty;

            try
            {
                bool Status = unitofwork.CategoryImplObject.Update(Id, updatedCategory);

                if (Status)
                {
                    unitofwork.SaveAll();
                    return Ok(updatedCategory);
                }
                else
                {
                    errorMessage = "Error updating category.";
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return BadRequest(errorMessage);
        }

        [HttpDelete]
        public IActionResult RemoveCategory(int id)
        {
            bool Status = unitofwork.CategoryImplObject.Delete(id);

            if (Status)
            {
                unitofwork.SaveAll();
                return Ok($"Category with Id {id} has been deleted.");
            }
            else
            {
                return NotFound($"Category with Id {id} not found or unable to delete.");
            }
        }
    }
}
