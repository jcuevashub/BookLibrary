using BookLibrary.Core.Models;
using BookLibrary.Services.Authors;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.WebAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _authorService.GetAllAuthors();

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] int Id)
        {
            var response = _authorService.GetAuthorById(Id);

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            var response = _authorService.InsertAuthor(author);

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            _authorService.DeleteAuthor(Id);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Author author)
        {
            var response = _authorService.UpdateAuthor(author);

            if (response == null)
                return BadRequest(response);

            return Ok(response.Result);
        }
    }
}
