using BooksAPI.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Data.Entities
{
    [Table(name: "BookGenres")]
    public class BookGenre : BaseEntity
    {
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
