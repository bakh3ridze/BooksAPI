using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Service.GenreService.Commands
{
    public class ModifyGenreCommand
    {
        [Required]
        public string? Name { get; set; }
    }

    public class ModifyGenreCommandalidator : AbstractValidator<ModifyGenreCommand>
    {
        public ModifyGenreCommandalidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
