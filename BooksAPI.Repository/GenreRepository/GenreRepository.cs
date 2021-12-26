using BooksAPI.Data;
using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepository;
using BooksAPI.Repository.BookRepository;
using BooksAPI.Repository.GenreRepository.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.GenreRepositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<BookGenre> _bookGenreRepository;

        public GenreRepository(BookContext context, IRepository<Genre> genreRepository, IRepository<BookGenre> bookGenreRepository) : base(context)
        {
            _genreRepository = genreRepository;
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<bool> Create(CreateGenreCommand command)
        {
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }
            bool ifSuccesful = await _genreRepository
                .Insert
                (
                new Genre() { Name = command.Name }
                );
            return ifSuccesful;
        }
        public async Task<bool> Update(UpdateGenreCommand command, int Id)
        {
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }
            bool ifSuccesful = await _genreRepository
                .Update
                (
                 new Genre() { Name = command.Name, Id = Id },
                Id
                );
            return ifSuccesful;
        }


    }
}
