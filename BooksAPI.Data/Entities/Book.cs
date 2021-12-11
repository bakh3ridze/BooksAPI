using BooksAPI.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Data.Entities
{
    [Table(name: "Books")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public ICollection<BookGenre> Genres { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 100)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
