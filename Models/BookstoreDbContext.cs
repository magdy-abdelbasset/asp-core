using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AspNetCoreDemo.Models
{
    public class BookstoreDbContext:DbContext
    {

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options):base(options)
        {

        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=AuthorDB;User Id=SA;password=So102030@#$;Trusted_Connection=False;MultipleActiveResultSets=true;");
    }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}