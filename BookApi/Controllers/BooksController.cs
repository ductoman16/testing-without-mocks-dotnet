using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get() => _bookService.Get();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookService.Get(id);
            if (book == null)
                return NotFound();
            return book;
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Book), 201)]
        public IActionResult Create([FromBody] BookCreateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublishedYear = bookDto.PublishedYear,
                Description = bookDto.Description
            };
            _bookService.Create(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.Get(id);
            if (book == null)
                return NotFound();
            _bookService.Update(id, bookIn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);
            if (book == null)
                return NotFound();
            _bookService.Remove(id);
            return NoContent();
        }
    }
}