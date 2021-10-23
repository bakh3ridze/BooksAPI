using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Data.Base
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
    }
}
