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
    [Table(name: "Countries")]
    public class Country : BaseEntity
    {
        public string Name { get; set; }
    }
}
