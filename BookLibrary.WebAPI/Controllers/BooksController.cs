using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Core.Models;
using BookLibrary.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.WebAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _bookService.GetAllBooks();

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var response = _bookService.GetBookById(Id);

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            var response = _bookService.InsertBook(book);

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _bookService.DeleteBook(Id);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            var response = _bookService.UpdateBook(book);

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }
    }
}
