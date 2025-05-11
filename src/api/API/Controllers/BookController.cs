using API.DTO;
using API.Helpers;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    
    public class BookController(IGenericRepository<Book> repo) : BaseApiController
    {
        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] BookSpecParams specParams)
        {
            specParams.IsPaginationEnabled = true;
            var specs = new BookSpecification(specParams);

            var pagination = await GetPaginationAsync(repo, specs,specParams.PageSize,specParams.PageIndex);

            return Ok(pagination);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var book = await repo.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]BookCreationDto bookDto)
        {
            if(bookDto == null)
            {
                return BadRequest();
            }
            var book = Book.Create(bookDto.Description, bookDto.Title, bookDto.AuthorNames, bookDto.BookCoverPhoto, bookDto.Price, bookDto.AverageRating, bookDto.TotalReviews, bookDto.Genres, bookDto.CategoryId);

            repo.Add(book);

            if(await repo.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
            }
            return BadRequest();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody]BookCreationDto bookCreationDto)
        {
            if(bookCreationDto == null || bookCreationDto.Id != id)
            {
                BadRequest();
            }
            var existingBook = await repo.IsExists(id);
            if(!existingBook)
            {
                NotFound();
            }
            var book = await repo.GetByIdAsync(id);
            book?.UpdateBook(bookCoverPhoto: bookCreationDto!.BookCoverPhoto, title: bookCreationDto.Title, description: bookCreationDto.Description, authorNames: bookCreationDto.AuthorNames, price: bookCreationDto.Price, averageRating: bookCreationDto.AverageRating, totalReviews: bookCreationDto.TotalReviews, genres: bookCreationDto.Genres);

            repo.Update(book!);
            if(await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var book = await repo.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            repo.Delete(book);
            if(await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
