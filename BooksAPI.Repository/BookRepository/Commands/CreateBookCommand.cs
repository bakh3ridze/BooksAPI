using BooksAPI.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BookRepository.Commands
{
    public class CreateBookCommand
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 100)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<int>? GenreIds { get; set; }
    }
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Price).InclusiveBetween(1, 100);
        }
    }
}
