using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.GenreRepositories;
using BooksAPI.Repository.GenreRepository.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IBookRepository _bookRepository;
        public GenreController(IGenreRepository genreRepository, IBookRepository bookRepository)
        {
            _genreRepository = genreRepository;
            _bookRepository = bookRepository;
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
        public async Task<ActionResult> Create(CreateGenreCommand command)
        {
            bool ifSuccessful = await _genreRepository.Create(command);
            if (ifSuccessful != true)
                return StatusCode(500);
            return Ok(command);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(UpdateGenreCommand command, int Id)
        {
            Genre genre = await _genreRepository.GetById(Id);
            if (genre == null)
                return NotFound();
            bool ifSuccessful = await _genreRepository.Update(command, Id);
            if (ifSuccessful != true)
                return StatusCode(500);
            return Ok(command);
        }

        [HttpDelete("Delete/{Id}")]
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

        [HttpGet("GetGenresByBookId/{Id}")]
        public async Task<ActionResult> GetGenresByBookId(int Id)
        {
            Book? genre = await _bookRepository.GetById(Id);
            if (genre == null)
                return NotFound();
            return Ok(await _genreRepository.GetGenresByBookId(Id));
        }

        [HttpPost("AddGenresByBookId")]
        public async Task<ActionResult> AddGenresByBookId(int Id, IEnumerable<int>? Ids)
        {
            Book? genre = await _bookRepository.GetById(Id);
            if (genre == null)
                return NotFound();

            await _genreRepository.AddGenresByBookId(Id, Ids);

            return Ok();
        }
    }
}
