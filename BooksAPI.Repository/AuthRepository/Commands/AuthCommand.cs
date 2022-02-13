using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.AuthRepository.Commands
{
    public class AuthCommand
    {
        public string Email { get; set; }
        public string Passowrd { get; set; }
    }
}
