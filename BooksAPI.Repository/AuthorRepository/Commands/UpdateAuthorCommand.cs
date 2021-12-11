using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.AuthorRepository.Commands
{
    public class UpdateAuthorCommand
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.CountryId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
