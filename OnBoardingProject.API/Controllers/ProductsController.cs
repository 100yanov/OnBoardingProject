using Microsoft.AspNetCore.Mvc;
using OnBoardingProject.API.Repositories;
using OnBoardingProject.Common.Models;

namespace OnBoardingProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<ProductModel> repository;

        public ProductsController(IRepository<ProductModel> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            var entities = repository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(Guid id)
        {
            var entity = repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<ProductModel> Post([FromBody] ProductModel entity)
        {
            repository.Add(entity);
            repository.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }
 
        [HttpPut]
        public IActionResult Put([FromBody] ProductModel entity)
        {
            repository.Update(entity);
            repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            repository.SaveChanges();
            return NoContent();
        }
    }
}
