using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.CountryRepository.Commands
{
    public class UpdateCountryCommand
    {
        public string Name { get; set; }
    }

    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
