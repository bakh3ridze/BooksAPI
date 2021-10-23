using BooksAPI.Data.Entities;
using BooksAPI.Repository.BaseRepositories;
using BooksAPI.Service.GenreService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Service.GenreService
{
    public class GenreService
    {
        private readonly IRepository<Genre> _repository;

        public GenreService(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        public async Task CreateGenre(ModifyGenreCommand command)
        {
            ModifyGenreCommandalidator validator = new ModifyGenreCommandalidator();
            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                throw new Exception("FluentValidationExeption");
            }
            await _repository.Insert(
                new Genre
                {
                    Name = command.Name
                }
                );
        }
        public async Task UpdateGenre(ModifyGenreCommand command, int Id)
        {
            ModifyGenreCommandalidator validator = new ModifyGenreCommandalidator();
            var result = await validator.ValidateAsync(command);
            Genre ifExists = await _repository.GetById(Id);
            if (!result.IsValid && ifExists == null)
            {
                throw new Exception("FluentValidationExeption");
            }
            await _repository.Update(
                                new Genre
                                {
        Name = command.Name
                                },
                                Id
                );
        }
    }
}
