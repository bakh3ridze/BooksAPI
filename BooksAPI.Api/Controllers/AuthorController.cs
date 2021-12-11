using BooksAPI.Data.Entities;
using BooksAPI.Repository.AuthorRepository;
using BooksAPI.Repository.AuthorRepository.Commands;
using BooksAPI.Repository.GenreRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly AuthorRepository _author_repository;

        public AuthorController(AuthorRepository author_repository)
        {
            _author_repository = author_repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _author_repository.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            Author book = await _author_repository.GetById(Id);

            if(book == null)
            {
                return StatusCode(404);
            }

            return Ok(book);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(CreateAuthorCommand command)
        {
            bool is_successfull = await _author_repository.Create(command);

            if (is_successfull != true)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(int Id, UpdateAuthorCommand command)
        {
            Author country = await _author_repository.GetById(Id);

            if (country == null)
            {
                return StatusCode(404);
            }

            bool is_successfull = await _author_repository.Update(command, Id);

            if (is_successfull != true)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            Author genre = await _author_repository.GetById(Id);

            if (genre == null)
            {
                return StatusCode(404);
            }

            bool ifSuccessful = await _author_repository.Delete(Id);

            if (ifSuccessful != true)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
