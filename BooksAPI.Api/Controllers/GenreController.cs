using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Service.GenreService;
using BooksAPI.Service.GenreService.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly GenreService _bookService;
        private readonly IRepository<Genre> _genreRepository;

        public GenreController(GenreService bookService, IRepository<Genre> repository)
        {
            _bookService = bookService;
            _genreRepository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _genreRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            Genre genre = await _genreRepository.GetById(Id);
            if (genre == null)
                return NotFound();
            return Ok(genre);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(ModifyGenreCommand command)
        {
            bool ifSuccessful = await _bookService.CreateGenre(command);
            if (ifSuccessful != true)
                return StatusCode(500);
            return Ok(command);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(ModifyGenreCommand command, int Id)
        {
            Genre genre = await _genreRepository.GetById(Id);
            if (genre == null)
                return NotFound();
            bool ifSuccessful = await _bookService.UpdateGenre(command, Id);
            if (ifSuccessful != true)
                return StatusCode(500);
            return Ok(command);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            Genre genre = await _genreRepository.GetById(Id);
            if (genre == null)
                return NotFound();
            bool ifSuccessful = await _genreRepository.Delete(Id);
            if (ifSuccessful != true)
                return StatusCode(500);
            return Ok();
        }
    }
}
