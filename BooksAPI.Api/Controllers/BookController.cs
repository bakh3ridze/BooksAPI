using BooksAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksAPI.Repository.Models;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.BookRepository.Commands;

namespace BooksAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _bookRepository.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            Book book = await _bookRepository.GetById(Id);

            if (book != null)
                return Ok(book);
            else
                return NotFound();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(CreateBookCommand command)
        {
            bool ifSuccessful = await _bookRepository.Create(command);
            if (ifSuccessful == true)
                return Ok(command);
            else
                return StatusCode(500);
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult> Update(UpdateBookCommand command, int Id)
        {
            Book ifExists = await _bookRepository.GetById(Id);
            if (ifExists == null)
                return NotFound();
            bool ifSuccessful = await _bookRepository.Update(command, Id);
            if (ifSuccessful == true)
                return Ok(command);
            else
                return StatusCode(500);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            Book ifExists = await _bookRepository.GetById(Id);
            if (ifExists == null)
                return NotFound();
            bool result = await _bookRepository.Delete(Id);
            if (result == true)
                return Ok();
            return StatusCode(500);
        }
        [HttpGet("DetailedBook/{Id}")]
        public async Task<ActionResult> DetailedBook(int Id)
        {
            Book ifExists = await _bookRepository.GetById(Id);
            if (ifExists == null)
                return NotFound();
            DetailedBook details = await _bookRepository.GetDetailedBook(Id);
            if (details != null)
                return Ok(details);
            else
                return NotFound();
        }

        [HttpGet("GetAllDetailedBook")]
        public async Task<ActionResult> GetAllDetailedBook()
        {
            List<DetailedBook> result = new List<DetailedBook>();
            foreach (var item in await _bookRepository.GetAll())
            {
                result.Add(await _bookRepository.GetDetailedBook(item.Id));
            }
            return Ok(result);
        }
    }
}
