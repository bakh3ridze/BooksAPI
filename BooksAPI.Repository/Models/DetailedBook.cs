using BooksAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.Models
{
    public class DetailedBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Author Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
