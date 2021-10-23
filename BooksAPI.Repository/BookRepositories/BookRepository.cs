using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BookRepositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly IRepository<Genre> _genreRepository;
        public BookRepository(BookContext context, IRepository<Genre> genreRepository) : base(context) 
        {
            _genreRepository = genreRepository;
        }


        public async Task<Details> Details(int Id)
        {
            Book? book = await _entities.SingleOrDefaultAsync(x => x.Id == Id);
            if (book != null)
            {
                Genre? BookGenre = await _genreRepository.GetById(book.GenreId);
                Details? details = new Details()
                {
                    GenreId = book.GenreId,
                    GenreName = BookGenre.Name,
                    Price = book.Price,
                    IsDeleted = book.IsDeleted,
                    Title = book.Title,
                    PublishDate = book.PublishDate
                };
                return details;
            }
            return null;
        }
    }
}
