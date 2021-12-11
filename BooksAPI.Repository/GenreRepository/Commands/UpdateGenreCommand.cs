using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.GenreRepository.Commands
{
    public class UpdateGenreCommand
    {
        [Required]
        public string? Name { get; set; }
    }

    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
