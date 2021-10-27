using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Service.Models
{
    public class Details
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
