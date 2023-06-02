using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Models.Repositories
{
    public class BookRepository :IBookstoreRepository<Book>
    {
        List<Book> books;
               public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,
                    Title ="C# Programming",
                    Description ="No description",
                    ImageUrl = "csharp.png",
                    Author = new Author{Id = 2 }
                },
                new Book
                {
                    Id=2,
                    Title ="Java Programming",
                    Description ="Nothing",
                    ImageUrl = "java.png",
                    Author = new Author()
                },
                new Book
                {
                    Id=3,
                    Title ="Python Programming",
                    Description ="No data",
                    ImageUrl = "python.png",
                    Author = new Author()
                },
            };
        }
 
        public IList<Book> List(){
            return books;
        }
        public Book Find(int Id){
            return books.SingleOrDefault(b => b.Id == Id);
        }
        public void Add(Book entity){
            books.Add(entity);
        }
        public void Update(int Id ,Book newBook){
         
            var book = Find(Id);

            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.ImageUrl = newBook.ImageUrl; 
        }
        public void Delete(int Id){
           books.Remove(Find(Id));
        }


        public List<Book> Search(string term)
        {
            throw new NotImplementedException();
        }
    }
}