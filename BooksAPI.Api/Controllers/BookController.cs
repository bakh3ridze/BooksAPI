using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Service.BookService;
using BooksAPI.Service.BookService.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksAPI.Repository.BookRepositories;
using BooksAPI.Service.Models;

namespace BooksAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly IRepository<Book> _repository;
        private readonly IBookRepository _bookRepository;

        public BookController(BookService bookService, IRepository<Book> repository, IBookRepository bookRepository)
        {
            _bookService = bookService;
            _repository = repository;
            _bookRepository = bookRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            Book book = await _repository.GetById(Id);
            if (book != null)
                return Ok(book);
            else
                return NotFound();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(ModifyBookCommand command)
        {
            bool ifSuccessful = await _bookService.CreateBook(command);
            if (ifSuccessful == true)
                return Ok(command);
            else
                return StatusCode(500);
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult> Update(ModifyBookCommand command, int Id)
        {
            Book ifExists = await _bookRepository.GetById(Id);
            if (ifExists == null)
                return NotFound();
            bool ifSuccessful = await _bookService.UpdateBook(command, Id);
            if (ifSuccessful == true)
                return Ok(command);
            else
                return StatusCode(500);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            Book ifExists = await _bookRepository.GetById(Id);
            if (ifExists == null)
                return NotFound();
            bool result = await _repository.Delete(Id);
            if (result == true)
                return Ok();
            return StatusCode(500);
        }
        [HttpGet("Details/{Id}")]
        public async Task<ActionResult> Details(int Id)
        {
            Details? details = await _bookService.Details(Id);
            if (details != null)
                return Ok(details);
            else
                return NotFound();
        }
    }
}
