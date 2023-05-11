using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Models.Repostries
{
    public class BookRepostry :IBookStoreRepostry<Book>
    {
        List<Book> list;
        public BookRepostry(){
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
            return books.SingleOrDefault(b => b.Id == id);
        }
        public void Add(TEntity entity){
            books.Add(entity);
        }
        public void Update(int id ,TEntity entity){
           var book =  Find(id);
           book.Title = entity.Title;
           book.Descreption = entity.Descreption;
           book.author = entity.author;
        }
        public void Delete(int Id){
           books.Remove(Find(id));
        }
    }
}