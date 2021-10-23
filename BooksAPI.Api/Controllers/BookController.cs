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

        [HttpGet("GetById/{Id}")]
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
             await _bookService.CreateBook(command);
             return Ok(command);
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult> Update(ModifyBookCommand command, int Id)
        {
            await _bookService.UpdateBook(command, Id);
            return Ok(command);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            bool result = await _repository.Delete(Id);
            if (result == true)
                return Ok();
            return NotFound();
        }
        [HttpGet("Details/{Id}")]
        public async Task<ActionResult> Details(int Id)
        {
            Details? details = await _bookRepository.Details(Id);
            if (details != null)
                return Ok(details);
            else
                return NotFound();
        }
    }
}
