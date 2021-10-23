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
        private readonly IRepository<Genre> _repository;

        public GenreController(GenreService bookService, IRepository<Genre> repository)
        {
            _bookService = bookService;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            return Ok(await _repository.GetById(Id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(ModifyGenreCommand command)
        {
            await _bookService.CreateGenre(command);
            return Ok(command);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(ModifyGenreCommand command, int Id)
        {
            await _bookService.UpdateGenre(command, Id);
            return Ok(command);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            bool result = await _repository.Delete(Id);
            if (result == true)
                return Ok();
            return Conflict();
        }
    }
}
