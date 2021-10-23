using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksAPI.Data.Entities;
using BooksAPI.Data.Base;

namespace BooksAPI.Sdk.Book
{
    public class HttpBookService
    {
        private HTTPHelper _httpHelper { get; set; }
        public HttpBookService(HTTPHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }
        public async Task<IEnumerable<Book>> List()
        {
            try
            {
                var result = await _httpHelper.Get<IEnumerable<Book>>($"/api/Book/GetAll");
                return result;
            }
            catch (Exception x)
            {
                throw;
            }
        }
    }

    public class Book : BaseEntity
    {
        public string? Title { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
