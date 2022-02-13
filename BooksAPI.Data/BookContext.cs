using BooksAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext() { }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set;  }
        public DbSet<Author> Authors { get; set;  }
        public DbSet<BookGenre> BookGenres { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-B3Q553I;Initial Catalog=BooksDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
