using BooksAPI.Repository.AuthRepository.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<string> GenerateToken();
    }
}
