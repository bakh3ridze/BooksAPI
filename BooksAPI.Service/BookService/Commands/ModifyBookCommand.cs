using BooksAPI.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Service.BookService.Commands
{
    public class ModifyBookCommand
    {
        [Required]
        public string? Title { get; set; }

        public int GenreId { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 100)]
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class CreateBookCommandValidator : AbstractValidator<ModifyBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Price).InclusiveBetween(1, 100);
        }
    }
}
