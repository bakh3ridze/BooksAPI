using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.CountryRepository.Commands
{
    public class CreateCountryCommand
    {
        public string Name { get; set; }
    }

    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
