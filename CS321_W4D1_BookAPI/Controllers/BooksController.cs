using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        // Constructor
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var bookModels = _bookService
                .GetAll()
                .ToApiModels(); // convert Books to BookModels

            return Ok(bookModels);
        }

        // TODO: Add a route that returns all books for an author
        // GET api/author/{authorId}/books
        [HttpGet("/api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(authorId)
                .ToApiModels();

            return Ok(bookModels);
        }

        // get specific book by id
        // GET api/books/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);
            if (book == null) return NotFound();
            return Ok(book.ToApiModel());
        }

        // create a new book
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] BookModel newBook)
        {
            try
            {

                // add the new book
                _bookService.Add(newBook.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddBook", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newBook.Id }, newBook);
        }

        // PUT api/books/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel updatedBook)
        {
            var book = _bookService.Update(updatedBook.ToDomainModel());
            if (book == null) return NotFound();
            return Ok(book.ToApiModel());
        }

        // DELETE api/books/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book == null) return NotFound();
            _bookService.Remove(book);
            return NoContent();
        }
    }
}
