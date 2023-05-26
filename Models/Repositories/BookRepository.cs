using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Models.Repositories
{
    public class BookRepository :IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository(){
            books = new List<Book>(){
                new Book {
                    Id =1,Title="kjsjk",Descreption="sccsdcsdds",
                },
                new Book {
                    Id =2,Title="kjsjk",Descreption="sccsdcsdds",
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
        public void Update(int Id ,Book entity){
           var book =  Find(Id);
           book.Title = entity.Title;
           book.Descreption = entity.Descreption;
           book.author = entity.author;
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