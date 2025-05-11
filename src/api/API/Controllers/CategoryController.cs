using Core.Entities;
using Core.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController(IGenericRepository<Category> repo) : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var categories = await repo.GetAllAsync();
            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var category = await repo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            repo.Add(category);
            if (await repo.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody]Category category)
        {
            if (category == null || category.Id != id)
            {
                return BadRequest();
            }
            var existingCategory = await repo.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            repo.Update(category);
            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await repo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            repo.Delete(category);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
