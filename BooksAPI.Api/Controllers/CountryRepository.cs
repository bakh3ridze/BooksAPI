using BooksAPI.Data.Entities;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.CountryRepositories;
using BooksAPI.Repository.CountryRepository;
using BooksAPI.Repository.CountryRepository.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BooksAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _country_repository;

        public CountryController(ICountryRepository country_repository)
        {
            _country_repository = country_repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _country_repository.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {
            Country book = await _country_repository.GetById(Id);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(CreateCountryCommand command)
        {
            bool is_successfull = await _country_repository.Create(command);

            if(is_successfull != true)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(int Id, UpdateCountryCommand command)
        {
            Country country = await _country_repository.GetById(Id);

            if(country == null)
            {
                return StatusCode(404);
            }

            bool is_successfull = await _country_repository.Update(command, Id);

            if (is_successfull != true)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            Country genre = await _country_repository.GetById(Id);

            if (genre == null)
            {
                return StatusCode(404);
            }

            bool ifSuccessful = await _country_repository.Delete(Id);

            if (ifSuccessful != true)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
