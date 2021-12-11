using BooksAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BooksAPI.Repository.Models;

namespace BooksAPI.SDK2.BookHttpClient
{
    public class BookHttpClient : IBookHttpClient
    {
        private HttpClient _httpClient;

        public BookHttpClient(HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            IEnumerable<Book> BookList = await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("/api/Book/GetAll");
            return BookList;
        }

        public async Task<IEnumerable<DetailedBook>> GetAllDetailedBook()
        {
            IEnumerable<DetailedBook> BookList = await _httpClient.GetFromJsonAsync<IEnumerable<DetailedBook>>("/api/Book/GetAllDetailedBook");
            return BookList;
        }
    }
}
