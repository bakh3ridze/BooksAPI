using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.AuthorRepository.Commands
{
    public class CreateAuthorCommand
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.CountryId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
