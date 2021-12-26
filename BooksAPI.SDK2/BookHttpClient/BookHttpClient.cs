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

        public BookHttpClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BookHttpClient");
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>(_httpClient.BaseAddress + "/Book/GetAll");
        }

        public async Task<IEnumerable<DetailedBook>> GetAllDetailedBook()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DetailedBook>>(_httpClient.BaseAddress + "/Book/GetAllDetailedBook");
        }
    }
}
